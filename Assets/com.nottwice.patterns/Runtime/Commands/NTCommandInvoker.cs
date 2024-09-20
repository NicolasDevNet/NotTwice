using System;
using System.Collections.Generic;
using UnityEngine;
using NotTwice.Patterns.Commands.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using NotTwice.Patterns.DependancyRegistration.Runtime;

namespace NotTwice.Patterns.Commands.Runtime
{
    /// <summary>
    /// Component class used to execute scriptable commands created upstream and entered in the data set <see cref="Commands"/>.
    /// </summary>
    [CreateAssetMenu(fileName = "CommandInvoker", menuName = "NotTwice/Patterns/Commands/CommandInvoker")]
	public class NTCommandInvoker : ScriptableObject, INTCommandInvoker
	{
		#region Fields

		[Required, Expandable, Tooltip("Dependency container to be used for commands")]
		public NTDependancyContainer Container;

		[MinValue(1), Tooltip("Defines the number of orders that will be kept in the history")]
		public int MaxCommandHistory;

        #endregion

        #region Properties

        private Stack<NTBaseCommand> _history = new Stack<NTBaseCommand>();

		#endregion

		public void Initialize()
		{
			_history = new Stack<NTBaseCommand>();
		}

		#region Sync with params

		public void ExecuteCommand<T>(params object[] args)
			where T : NTBaseCommand
		{
			ExecuteCommandInternal(CreateCommandInstance<T>(), args);
		}

		public void UndoCommand(params object[] args)
		{
			UndoCommandInternal(args);
		}

		#endregion

		#region Async with params

		public async UniTask ExecuteCommandAsync<T>(params object[] args)
			where T : NTBaseCommand
		{
			await ExecuteCommandInternalAsync(CreateCommandInstance<T>(), args);
		}

		public async UniTask UndoCommandAsync(params object[] args)
		{
			await UndoCommandInternalAsync(args);
		}

		#endregion

		#region Tools

		private void ExecuteCommandInternal(NTBaseCommand command, params object[] args)
		{
            NTCommand parsedCommand = command as NTCommand;

            try
			{
				if (parsedCommand.CanExecute())
				{
					parsedCommand.Execute(args);
					_history.Push(command);
				}
			}
			catch (Exception)
			{
				_history.Pop();
				throw;
			}
		}

		private void UndoCommandInternal(params object[] args)
		{
			if (_history.TryPop(out NTBaseCommand command) && command is NTCommand parsedCommand)
			{
				parsedCommand.Undo(args);
			}
		}

		private async UniTask ExecuteCommandInternalAsync(NTBaseCommand command, params object[] args)
		{
			NTAsyncCommand parsedCommand = command as NTAsyncCommand;

            if (_history.Count >= MaxCommandHistory)
            {
                _history.Clear();
            }

            try
			{
				if (await parsedCommand.CanExecuteAsync())
				{
					await parsedCommand.ExecuteAsync(args);
					_history.Push(command);
				}
			}
			catch (Exception)
			{
				_history.Pop();
				throw;
			}
		}

		private async UniTask UndoCommandInternalAsync(params object[] args)
		{
			if (_history.TryPop(out NTBaseCommand command) && command is NTAsyncCommand parsedCommand)
			{
				await parsedCommand.UndoAsync(args);
			}
		}

		private T CreateCommandInstance<T>()
            where T : NTBaseCommand
		{
            return (T)Activator.CreateInstance(typeof(T), Container);
        }

		#endregion

		#region Editor

#if UNITY_EDITOR

		[Button]
		public void ShowHistory()
		{
			foreach (NTBaseCommand command in _history)
			{
				Debug.Log(command.GetType().Name);
			}
		}

#endif

		#endregion
	}
}
