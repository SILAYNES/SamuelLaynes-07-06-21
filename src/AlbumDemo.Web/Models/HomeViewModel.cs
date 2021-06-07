using System.Collections.Generic;

namespace AlbumDemo.Web.Models
{
    public class HomeViewModel
    {
        public List<AlbumViewModel> Albums { get; set; }
        public string ActionText { get; set; }
    }
}