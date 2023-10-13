# NotTwice
NotTwice est une suite de librairies dont l’objectif est de fournir des outils d’amélioration de qualité de vie pour un développeur Unity.
De manière générale, la librairie vise à mieux structurer le code d'un jeu et à créer une séparation nette (dans la mesure du possible) entre les scripts et l'éditeur Unity.

## NotTwice.DI
Cette librairie fonctionne comme d'autres conteneurs .NET connus mais embarque aussi un système d'injection pour Unity qui diffère des systèmes classiques.
Il est nécessaire de passer par un MonoBehaviour de démarrage qui va chercher les autres MonoBehaviours qui ont besoin d'une injection de depéndances.
Ce besoin d'injection va être marqué par une méthode à la main du développeur mais qui doit être marquée avec l'attribut [Resolve].
C'est cette méthode qui va être exécuté avant qu'Unity n'appelle les composants de la scène dans l'ordre définit.

Le conteneur fournit des méthodes pour les injections de Transient, de Singletons et d'Instances.

## NotTwice.Pools
Cette librairie fournit différents outils pour optimiser le cycle de vie d'instances qui ont besoin d'être crées ou détruites fréquemment.
On retrouve donc une classe de base Poolable et une interface IPoolable qui sera à implémenter avec une classe de MonoBehaviour destinée à être clonée.
L'interface propose d'inplémentée une fonction d'instantiation ou de sortie de pool, de réinitialisation et de remise en pool.

Un nombre limité d'instances peut-être définit dans le constructeur de base de Poolable, par défaut, on limite la création à 10 instances avant de réutiliser les existantes.
La valeur par défaut est volontairement réduite étant donné qu'on aura souvent tendance à utiliser une valeur par défaut.


## NotTwice.Addressables
