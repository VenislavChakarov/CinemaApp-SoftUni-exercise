namespace CinemaApp.Data.Common;

public static class EntityConstants
{
    public static class Movie
    {
        public const int TitleMaxLength = 100;
        public const int DescriptionMaxLength = 1000;
        public const int DirectorMaxLength = 100;
        public const int GenreMaxLength = 50;
        public const int ImageUrlMaxLength = 2048; // URL length
        public const int DurationMin = 1; // in minutes
        public const int DurationMax = 300; // in minutes, assuming a maximum of 10 hours
    }
}