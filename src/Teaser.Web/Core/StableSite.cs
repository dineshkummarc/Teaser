using System;

namespace Teaser.Web.Core
{
	public static class StableSite
	{
		public static class Nav
        {
            public static readonly string Products = "products";
            public static readonly string Score = "Score";
		}

		public static class Screen
        {
            public static class Product
            {
                public static readonly string Index = "productIndex";
            }
            public static class Score
            {
                public static class Home
                {
                    public static readonly string Index = "ScoreHomeIndex";
                }
            }
		}
	}
}