namespace Watchlist.Data.Constants
{
    public static class DataConstants
    {
        // User Constants 
        public const int UserNameMinLength = 5;
        public const int UserNameMaxLength = 20;

        public const int UserEmailMinLength = 10;
        public const int UserEmailMaxLength = 60;

        public const int UserPasswordMinLength = 5;
        public const int UserPasswordMaxLength = 20;

        //Movie Constants 
        public const int MovieTitleMinLength = 10;
        public const int MovieTitleMaxLength = 50;

        public const int MovieDirectorMinLength = 5;
        public const int MovieDirectorMaxLength = 50;

        public const double MovieRatingMinValue = 0.00;
        public const double MovieRatingMaxValue = 10.00;

        //Genre Constants 
        public const int GenreNameMinLength = 5;
        public const int GenreNameMaxLength = 50;
    }
}
