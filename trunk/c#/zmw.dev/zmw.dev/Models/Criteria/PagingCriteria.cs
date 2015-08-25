using System.Linq;

namespace zmw.dev.Models.Criteria
{
    public class PagingCriteria
    {
        /// <summary>
        /// ページ番号
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// レコード件数
        /// </summary>
        public int TotalRecordCount { get; set; }

        /// <summary>
        /// TotalRecordCountが設定されている時に最大ページ番号を返す
        /// </summary>
        public int MaxPageNumber
        {
            get
            {
                if (TotalRecordCount <= 0)
                {
                    return 0;
                }
                return (TotalRecordCount - 1) / SizePerPage;
            }
        }

        /// <summary>
        /// 1ページの表示数。
        /// </summary>
        public int SizePerPage
        {
            get;
            set;
        }

        /// <summary>
        /// DB検索におけるオフセット値を返します
        /// </summary>
        /// <returns>オフセット値</returns>
        public int CalculateOffset()
        {
            int offset = 0;
            if (PageNumber >= 1)
            {
                offset = PageNumber * SizePerPage;
            }
            return offset;
        }

        public void ResetPageNumberByMaxPage(int maxPage)
        {
            if (PageNumber > maxPage) PageNumber = maxPage;
        }

    }
}