using System;
using System.Collections.Generic;
using System.Text;

namespace PixivApi.Model.Response
{
    public class IllustsListingResponse
    {
        public IEnumerable<Illusts> illusts { get; set; }
    }

    public class UserDetailResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Profile profile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Workspace workspace { get; set; }
    }

    public class UserListingResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public List<User_previewsItem> user_previews { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string next_url { get; set; }
    }

    public class Image_urls
    {
        /// <summary>
        /// 
        /// </summary>
        public string square_medium { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string medium { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string large { get; set; }
    }

    public class Profile_image_urls
    {
        /// <summary>
        /// 
        /// </summary>
        public string medium { get; set; }
    }

    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 红颜
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Profile_image_urls profile_image_urls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_followed { get; set; }
    }

    public class TagsItem
    {
        /// <summary>
        /// 珂朵莉
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string translated_name { get; set; }
    }

    public class Meta_single_page
    {
        /// <summary>
        /// 
        /// </summary>
        public string original_image_url { get; set; }
    }

    public class Illusts
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 珂朵莉
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Image_urls image_urls { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string caption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int restrict { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TagsItem> tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> tools { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string create_date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int page_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sanity_level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int x_restrict { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Meta_single_page meta_single_page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
        public int total_view { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_bookmarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_bookmarked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string visible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_muted { get; set; }
    }

    public class User_previewsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> illusts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> novels { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_muted { get; set; }
    }

    public class Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public string webpage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string birth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// IT关联
        /// </summary>
        public string job { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_follow_users { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_follower { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_mypixiv_users { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_illusts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_manga { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_novels { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total_illust_bookmarks_public { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string background_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string twitter_account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string twitter_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_premium { get; set; }
    }

    public class Workspace
    {
        /// <summary>
        /// 
        /// </summary>
        public string pc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string monitor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tool { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string scanner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tablet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mouse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string printer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desktop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string music { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string chair { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string workspace_image_url { get; set; }
    }


}
