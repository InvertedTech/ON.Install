using System;

namespace ON.SimpleWeb.Models.Page
{
    public class PageNumViewModel
    {
        public int CurrentPageNum { get; set; }
        public int TotalPageNum { get; set; }
        public int StartPageNum { get; set; }
        public int EndPageNum { get; set; }
        public string UrlBase { get; set; }

        public PageNumViewModel(int currentPageNum, int totalPageNum, string urlBase)
        {
            CurrentPageNum = currentPageNum;
            TotalPageNum = totalPageNum;
            UrlBase = urlBase;

            if (CurrentPageNum < 1)
                CurrentPageNum = 1;
            if (TotalPageNum < 1)
                TotalPageNum = 1;

            StartPageNum = ((CurrentPageNum - 1) / 5) * 5 + 1;
            EndPageNum = Math.Min(StartPageNum + 4, TotalPageNum);
        }
    }
}
