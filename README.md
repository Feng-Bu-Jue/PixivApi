## PixivApi
Pixiv API for dotnet
Direct using without need proxy (through PixivEndPointProvider configure fixed endpoint to bypass DNS)

## Usage

```c#
var pixivApiClient = new PixivApiClientFactory(Username, Password).Create<IPixivApiClient>();
var response = await pixivApiClient.SearchIllust();
```
