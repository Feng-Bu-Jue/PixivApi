## PixivApi
Pixiv API for DotNet

Directly using without the need proxy (configure fixed endpoint to bypass DNS)

## Install
Please refer to https://www.myget.org/feed/fengbujue/package/nuget/PixivApi

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
Task<IllustsListResponse> SearchIllust(string word, [EnumCastString] Sort sort = Sort.date_desc, [EnumCastString]SearchTag search_target = SearchTag.partial_match_for_tags, string filter = "for_ios", int? offset = null);

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
Task<IllustsListResponse> IllustRecommended(string content_type = "illust", bool include_ranking_label = true, string filter = "for_ios");

[HttpGet]
[Authorize]
[Route("v1/illust/ranking")]
Task<IllustsListResponse> IllustRanking([EnumCastString]RankingMode mode = RankingMode.day, string filter = "for_ios", string date = null, int? offset = null);

[HttpPost]
[Authorize]
[Route("v1/illust/bookmark/add")]
Task<IHttpResult<string>> IllustBookmarkAdd(int illust_id, string restrict = "public");

[HttpPost]
[Authorize]
[Route("v1/illust/bookmark/delete ")]
Task<IHttpResult<string>> IllustBookmarkDelete(int illust_id);

[HttpGet]
[Authorize]
[Route("/v1/trending-tags/illust")]
Task<string> TrendingTag(string filter = "for_ios");

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
