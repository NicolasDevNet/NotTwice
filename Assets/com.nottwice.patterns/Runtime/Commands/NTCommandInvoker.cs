using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NotTwice.ScriptableObjects.Runtime.Collections;
using NotTwice.Patterns.Commands.Runtime.Abstract;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using Assets.com.nottwice.patterns.Runtime.Commands;

namespace NotTwice.Patterns.Commands.Runtime
{
    /// <summary>
    /// Scriptable class used to execute scriptable commands created upstream and entered in the data set <see cref="Commands"/>.
    /// </summary>
    [CreateAssetMenu(fileName = "CommandInvoker", menuName = "NotTwice/Patterns/Commands/CommandInvoker")]
    public class NTCommandInvoker : ScriptableObject
    {
        #region Fields

        /// <summary>
        /// DataSet of commands used to search for the commands to be used by this invoker
        /// </summary>
        [Tooltip("DataSet of commands used to search for the commands to be used by this invoker")]
        [Expandable ,Required]
        public NTCommandsDataSet Commands;

        /// <summary>
        /// Prefix used to search for the name of the command in the arguments passed as parameters to the invoker
        /// </summary>
        [Tooltip("Prefix used to search for the name of the command in the arguments passed as parameters to the invoker")]
        public string CommandNamePrefix = "name:";

        private Stack<NTBaseCommand> _history = new Stack<NTBaseCommand>();

        #endregion

        #region Properties

        #endregion

        public void Initialize()
        {
            _history = new Stack<NTBaseCommand>();
        }

        #region Unity messages

        protected virtual void OnEnable()
        {
            _history = new Stack<NTBaseCommand>();
        }

        protected virtual void OnDisable()
        {
            _history = new Stack<NTBaseCommand>();
        }

        #endregion

        #region Sync with reference provided

        public void ExecuteCommand(NTBaseCommand command)
        {
            ExecuteCommandInternal(command);
        }

        public void UndoCommand()
        {
            UndoCommandInternal();
        }

        #endregion

        #region Async with reference provided

        public async UniTask ExecuteCommandAsync(NTBaseCommand command)
        {
            await ExecuteCommandInternalAsync(command);
        }

        public async UniTask UndoCommandAsync()
        {
            await UndoCommandInternalAsync();
        }

        #endregion

        #region Sync with params

        public void ExecuteCommand<T>(params object[] args)
            where T : NTBaseCommand
        {
            NTBaseCommand command = FindCommandFromArgs<T>(args);

            ExecuteCommandInternal(command, args);
        }

        public void UndoCommand<T>(params object[] args)
        {
            UndoCommandInternal(args);
        }

        #endregion

        #region Async with params

        public async UniTask ExecuteCommandAsync<T>(params object[] args)
            where T : NTBaseCommand
        {
            NTBaseCommand command = FindCommandFromArgs<T>(args);

            await ExecuteCommandInternalAsync(command, args);
        }

        public async UniTask UndoCommandAsync<T>(params object[] args)
        {
            await UndoCommandInternalAsync(args);
        }

        #endregion

        #region Sync with name

        public void ExecuteCommand<T>(string commandName)
            where T : NTBaseCommand
        {
            NTBaseCommand command = Commands.FindCommand<T>(commandName);

            ExecuteCommandInternal(command);
        }

        #endregion

        #region Async with name

        public async UniTask ExecuteCommandAsync<T>(string commandName)
            where T : NTBaseCommand
        {
            NTBaseCommand command = Commands.FindCommand<T>(commandName);

            await ExecuteCommandInternalAsync(command);
        }

        #endregion

        #region Sync with name

        public void ExecuteCommand<T>(NTStringVariable commandName)
            where T : NTBaseCommand
        {
            EnsureStringVariableNameIsValid(commandName);

            NTBaseCommand command = Commands.FindCommand<T>(commandName.Value);

            ExecuteCommandInternal(command);
        }

        #endregion

        #region Async with name

        public async UniTask ExecuteCommandAsync<T>(NTStringVariable commandName)
            where T : NTBaseCommand
        {
            EnsureStringVariableNameIsValid(commandName);

            NTBaseCommand command = Commands.FindCommand<T>(commandName.Value);

            await ExecuteCommandInternalAsync(command);
        }

        #endregion

        #region Tools

        private void ExecuteCommandInternal(NTBaseCommand command, params object[] args)
        {
            ValidateAndParseCommand(command, out NTCommand parsedCommand);

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
            if (_history.TryPop(out NTBaseCommand command))
            {
                ValidateAndParseCommand(command, out NTCommand parsedCommand);

                parsedCommand.Undo(args);
            }
        }

        private async UniTask ExecuteCommandInternalAsync(NTBaseCommand command, params object[] args)
        {
            ValidateAndParseCommand(command, out NTAsyncCommand parsedCommand);

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
            if (_history.TryPop(out NTBaseCommand command))
            {
                ValidateAndParseCommand(command, out NTAsyncCommand parsedCommand);

                await parsedCommand.UndoAsync(args);
            }
        }

        private bool ReadCommandNameFromArgs(object[] args, out string commandName)
        {
            commandName = args.OfType<string>()
                      .FirstOrDefault(arg => arg.Contains(CommandNamePrefix));

            return string.IsNullOrEmpty(commandName.Split(CommandNamePrefix)[1]);
        }

        private T FindCommandFromArgs<T>(object[] args)
            where T : NTBaseCommand
        {
            if (!ReadCommandNameFromArgs(args, out string commandName))
            {
                throw new Exception($"Impossible to deduce the name of the command from the arguments supplied, prefix set: {CommandNamePrefix}");
            }

            return Commands.FindCommand<T>(commandName);
        }

        private void ValidateAndParseCommand<T>(NTBaseCommand command, out T parsedCommand)
            where T : NTBaseCommand
        {
            if (command == null || !Commands.DataSet.Contains(command))
                throw new Exception("The command you want to run cannot be found.");

            parsedCommand = command as T;

            if (parsedCommand == null)
                throw new Exception($"The command supplied is not valid for {typeof(T).Name} execution");
        }

        public void EnsureStringVariableNameIsValid(NTStringVariable commandName)
        {
            if(commandName != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(commandName));
        }

        #endregion

        #region Editor

#if UNITY_EDITOR

        [Button]
        public void ShowHistory()
        {
            foreach (NTBaseCommand command in _history)
            {
                Debug.Log(command.name);
            }
        }

#endif

        #endregion
    }
}
