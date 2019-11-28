## PixivApi.Net
Pixiv API for DotNet

without needing proxy (direct connect by non-SNI sslstream)

## Install
Please refer to [Azure Feed](https://dev.azure.com/SourceFromGithub/fengbujue/_packaging?_a=package&feed=GithubFeed&package=PixivApi.Net&protocolType=NuGet)

## Usage

```c#
var pixivApiClient = new PixivApiClientFactory(Username, Password).Create<IPixivApiClient>();
var response = await pixivApiClient.SearchIllust();
```

## Included Apis

```c#
[HttpGet]
[Route("")]
Task<IHttpResult<Stream>> Download([Uri]string uri);

[HttpGet]
[Authorize]
[Route("v1/search/illust")]
Task<IllustsListResponse> SearchIllust(string word,
    [CastString] Sort sort = Sort.date_desc,
    [CastString]SearchTag search_target = SearchTag.partial_match_for_tags,
    [CastString]bool merge_plain_keyword_results = true,
    string filter = "for_ios",
    int? offset = null);

[HttpGet]
[Authorize]
[Route("v2/search/autocomplete")]
Task<IHttpResult<string>> SearchAutocomplete(string word, [CastString]bool merge_plain_keyword_results = true);

[HttpGet]
[Authorize]
[Route("v2/illust/related")]
Task<IllustsListResponse> IllustRelated(int illust_id, string filter = "for_ios");

[HttpGet]
[Authorize]
[Route("v2/illust/follow")]
Task<IllustsListResponse> IllusFollow(string restrict = "public", int? offset = null);

[HttpGet]
[Authorize]
[Route("v1/illust/detail")]
Task<Illusts> IllustDetail(int illust_id);

[HttpGet]
[Authorize]
[Route("v1/illust/recommended")]
Task<IllustsListResponse> IllustRecommended(string content_type = "illust", [CastString]bool include_ranking_label = true, string filter = "for_ios");

[HttpGet]
[Authorize]
[Route("v1/illust/ranking")]
Task<IllustsListResponse> IllustRanking([CastString]RankingMode mode = RankingMode.day, string filter = "for_ios", string date = null, int? offset = null);

[HttpPost]
[Authorize]
[Route("v1/illust/bookmark/add")]
Task<IHttpResult<string>> IllustBookmarkAdd(int illust_id, string restrict = "public");

[HttpPost]
[Authorize]
[Route("v1/illust/bookmark/delete")]
Task<IHttpResult<string>> IllustBookmarkDelete(int illust_id);

[HttpGet]
[Authorize]
[Route("v1/trending-tags/illust")]
Task<TrendTagListResponse> TrendingTag(string filter = "for_ios");

[HttpGet]
[Authorize]
[Route("v1/user/following")]
Task<UserListResponse> UserFollowing(int user_id, string restrict = "public", int? offset = null);

[HttpGet]
[Authorize]
[Route("v1/user/detail")]
Task<UserDetailResponse> UserDetail(int user_id, string filter = "for_ios");

[HttpGet]
[Authorize]
[Route("v1/user/recommended")]
Task<UserListResponse> UserRecommended(string filter = "for_ios", int? offset = null);

[HttpGet]
[Authorize]
[Route("v1/user/bookmarks/illust")]
Task<IllustsListResponse> UserBookmarkIllust(int user_id, string restrict = "public");

[HttpPost]
[Authorize]
[Route("v1/user/follow/add")]
Task<IHttpResult<string>> UserFollowAdd(int user_id, string restrict = "public");

[HttpPost]
[Authorize]
[Route("v1/user/follow/delete")]
Task<IHttpResult<string>> UserFollowDelete(int user_id);
```

## Thanks for these projects
[pixivpy](https://github.com/upbit/pixivpy)

[Pix-EzViewer](https://github.com/Notsfsssf/Pix-EzViewer)
