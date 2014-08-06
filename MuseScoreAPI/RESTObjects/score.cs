

using System;

namespace MuseScoreAPI.RESTObjects
{
    public class Score
    {
        public int ID { get; set; }
        public int Vid { get; set; }
        public Dates Dates { get; set; }
        public string Secret { get; set; }
        public string Uri { get; set; }
        public string Permalink { get; set; }
        public User User { get; set; }
        public string Status { get; set; }
        public string Sharing { get; set; }
        public int CommentCount { get; set; }
        public int FavoritingCount { get; set; }
        public int ViewCount { get; set; }
        public int PlaybackCount { get; set; }
        public int DownloadCount { get; set; }
        public string Genre { get; set; }
        public string Format { get; set; }
        public string License { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Metadata Metadata { get; set; }

        public string MetaTitleIfAvailable { get { return String.IsNullOrEmpty(Metadata.Title) ? Title : Metadata.Title; } }
        public string BindingUser { get { return "by User " + User.Username; } }
        public string BindingThumbnail { get { return "http://static.musescore.com/" + ID + "/" + Secret + "/thumb.png"; } }
    }
}
