using System;
using System.Collections.Generic;
using System.Text;

namespace PixivApi.Model
{
    public enum RankingMode
    {
        day,
        day_r18,
        day_male,
        day_male_r18,
        day_female,
        week_original,
        week_rookie,
        week,
        week_r18,
        week_r18g,
        month
    }

    public enum SearchTag
    {
        partial_match_for_tags,
        exact_match_for_tags,
        title_and_caption
    }

    public enum Sort
    {
        date_desc,
        date_asc
    }
}
