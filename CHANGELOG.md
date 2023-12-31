## [1.5.0](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/compare/1.4.0...1.5.0) (2023-12-22)


### Features

* allow the use of URIs for relationships with external DTs ([1f54f00](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/1f54f0010546fd93380163a53eaee95fe8bf1b64))


### Dependency updates

* **deps:** update dependency semantic-release-preconfigured-conventional-commits to v1.1.81 ([30a3bb1](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/30a3bb1170820ea3b776a85fc6fc9df2bdb7e79f))
* **deps:** update dependency semantic-release-preconfigured-conventional-commits to v1.1.82 ([e210495](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/e2104955246b1f77e2a020d2218fb14c78a98787))
* **deps:** update dependency semantic-release-preconfigured-conventional-commits to v1.1.83 ([e70663d](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/e70663d27fe8d4843d16879bae5d4bb9635e7a33))
* **deps:** update dependency semantic-release-preconfigured-conventional-commits to v1.1.84 ([fd4e683](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/fd4e683656a80b5eb19ffe64e5901e20698d107c))

## [1.4.0](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/compare/1.3.1...1.4.0) (2023-12-09)


### Features

* avoid the dependency of azure digital twin event type to consumers ([66adffa](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/66adffa1551d4f555e4ab496b75a41e41e6210a4))


### Dependency updates

* **deps:** update dependency semantic-release-preconfigured-conventional-commits to v1.1.80 ([daeca86](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/daeca86c35f66e3fdc432b12d571352d4f4b9bea))


### Build and continuous integration

* **deps:** update actions/setup-dotnet action to v4 ([5893eb6](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/5893eb6036946bbcac182edef7a3a00c13e8d241))

## [1.3.1](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/compare/1.3.0...1.3.1) (2023-12-05)


### Bug Fixes

* camel case in dtId field ([cbb20f8](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/cbb20f8e7bf2e94d5b0cac00d29e57acd3336f22))

## [1.3.0](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/compare/1.2.0...1.3.0) (2023-12-05)


### Features

* change events payload to improve processability ([a014351](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/a01435158e727402163046a169e4dc61dfd78fe6))


### Refactoring

* remove useless parameter in getDigitalTwinId ([7c48513](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/7c48513d4c1b4ce655dc1eda22c39482310d6ef0))

## [1.2.0](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/compare/1.1.0...1.2.0) (2023-12-04)


### Features

* add outgoing relationships to the status of the digital twin after each event ([f5d96c8](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/f5d96c82575c3bacdfac5b55e766e8700a322430))

## [1.1.0](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/compare/1.0.0...1.1.0) (2023-12-04)


### Features

* add complete status of the digital twin after each event ([20b40c0](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/20b40c099299756e74d756f1517124223f5c3a2a))


### Dependency updates

* **deps:** update azure azure-sdk-for-net monorepo ([a64ad12](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/a64ad12b9e63ebef32cd22e87d7184149e69cfa9))
* **deps:** update dependency semantic-release-preconfigured-conventional-commits to v1.1.79 ([e057459](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/e057459d46746c4bf3a25773837d9d820ceb910b))


### Build and continuous integration

* add mergify config ([9cb8fd9](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/9cb8fd97ce728ffd59624183836b2299a3014405))
* add renovate config ([8e9c151](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/8e9c151ece80a61c5ceca96c60ce00d1fc7f3c1e))


### General maintenance

* add Azure Identity deps ([b503aab](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/b503aab6409d69af1e037d0610bbfd7e4263034a))


### Refactoring

* move handling logic and avoid to send boilerplate data ([636ce81](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/636ce8192d9411b6ce43fb8e91d2953fc1787e2c))
* refactor code to handle events ([a9de2f7](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/a9de2f73c545b14660ede3a4b20ee04e3db1cde7))

## 1.0.0 (2023-11-30)


### Features

* implement broadcast to subscriber via signalr ([44ef7a7](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/44ef7a75eda2542c79885885aac19246d6eb0758))


### Build and continuous integration

* add build and deploy and release workflow ([52a4fee](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/52a4feef6851a3c889a4992e2273359c00ec9169))
* correct azure function app name ([0ea7750](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/0ea7750ee70c82d1e8ce4fc27458b1ed3c9944dc))
* remove useless build config ([0daae7c](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/0daae7c59f8f412dab0e2e39d843959934ffdede))
* set dotnet 6 instead of 8 ([2e39621](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/2e39621584196ca5593cba4c170de74d867d3a6a))


### General maintenance

* add base function template ([87770e8](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/87770e8b0418c42ac87be611a54201da5970be1b))
* add gitignore ([7c36a8f](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/7c36a8f03634a448950f4214454aad119bf49f76))
* change function name to broadcast and event type to CloudEvents ([abf9445](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/abf94459df645b20b999b9663c568a81f50c755d))
* turn the function to an event grid app template ([def22c1](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/def22c1ee011d70744a1c5077dbbe61a9e59433b))
* update gitignore ([2510e6a](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/2510e6a18eccc746c4af927955efd694b5ab6e39))
* update README ([b01e663](https://github.com/WebBased-WoDT/adt-digitaltwins-event-endpoint/commit/b01e663931f309732b73e57504a19d6b372058d7))
