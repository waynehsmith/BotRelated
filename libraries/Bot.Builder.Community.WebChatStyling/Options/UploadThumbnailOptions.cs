using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bot.Builder.Community.WebChatStyling
{
    public class UploadThumbnailOptions : StylingOption
    {
        public UploadThumbnailOptions(): base(typeof(Defaults)) { }

        public static class Defaults
        {
            public static bool Enable { get => true; }
            public static string ContentType { get => "image/jpeg";}
            public static int Height { get => 20; }
            public static int Width { get => 64; }
            public static double Quality { get => 0.6; }
        }


        [SimpleStyling("enableUploadThumbnail")]
        public bool Enable { get; set; } = Defaults.Enable;


        [SimpleStyling("uploadThumbnailContentType")]
        public string ContentType { get; set; } = Defaults.ContentType;

        [SimpleStyling("uploadThumbnailHeight")]
        public int? Height { get; set; } = Defaults.Height;

        [SimpleStyling("uploadThumbnailQuality")]
        public double? Quality { get; set; } = Defaults.Quality;



        [SimpleStyling("uploadThumbnailWidth")]
        public int? Width { get; set; } = Defaults.Width;

    }

}
