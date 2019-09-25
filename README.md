## PixivApi
Pixiv API for dotnet
## Usage

```c#
var pixivApiClient = new PixivApiClientFactory(Username, Password).Create<IPixivApiClient>();
var response = await pixivApiClient.SearchIllust();
```
