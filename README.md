## PixivApi
Pixiv API for DotNet

Directly using without need proxy (configure fixed endpoint to bypass DNS)

## Install
add the url to your package source config: `https://www.myget.org/F/fengbujue/api/v3/index.json`

run with package manager console: `Install-Package PixivApi`

## Usage

```c#
var pixivApiClient = new PixivApiClientFactory(Username, Password).Create<IPixivApiClient>();
var response = await pixivApiClient.SearchIllust();
```
