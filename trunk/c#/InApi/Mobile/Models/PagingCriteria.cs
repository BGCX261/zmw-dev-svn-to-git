
namespace Mobile.Models
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
        public int SizePerPage { get; set; }

        /// <summary>
        /// 1ページのあたりに表示する最大リンク数
        /// </summary>
        public int MaxLinksPerPage { get; set; }

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

        /// <summary>
        /// 開始ページ目を求める
        /// </summary>
        /// <returns>開始ページ目</returns>
        public virtual int PagingFrom
        {
            get
            {
                if ((PageNumber - 3) <= 0)
                {
                    return 1;
                }

                if (((PageNumber - 3) + MaxLinksPerPage - 1) > MaxPageNumber)
                {
                    var temp = MaxPageNumber - (MaxLinksPerPage - 1);
                    return temp > 0 ? temp : PageNumber - 3;
                }

                return (PageNumber - 3);
            }
        }

        /// <summary>
        /// 終了ページ目を求める
        /// </summary>
        /// <returns>終了ページ目</returns>
        public virtual int PagingTo
        {
            get
            {
                int pagingFrom = PagingFrom;

                if ((pagingFrom + MaxLinksPerPage) > (MaxPageNumber))
                {
                    return MaxPageNumber + 1;
                }

                return (pagingFrom + MaxLinksPerPage - 1);
            }
        }

    }
}