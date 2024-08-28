# NotTwice Pooling

## Description
Welcome to **NotTwice Pooling**, an open-source Library which allows you to better manage the creation or reuse of instances that you create during the lifetime of a game.

## Usage
To use this package, you need to create a pool in your project that inherits from NTGenericPool or a factory that inherits from NTGenericFactory. In the case of the pool, remember to use the initialization method when loading the scene. Then simply call the Get method to retrieve an instance or Release to free it.

## Installation
To install this package, use the UPM package addition via Unity:
https://github.com/NicolasDevNet/NotTwice.git?path=Assets/com.nottwice.pooling

## Dependencies

- "com.nottwice.events": "https://github.com/NicolasDevNet/NotTwice.git?path=Assets/com.nottwice.events"
- "com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm"

## Contribution
[Nicolas FOUQUE](https://nfodevfreelance.fr/)

## Support
[Nicolas FOUQUE](mailto:n.fouquedev@outlook.fr)

## Tickets
[Tickets](https://github.com/NicolasDevNet/NotTwice/issues)

## License
This project is open-source. Refer to the LICENSE file for more information.
