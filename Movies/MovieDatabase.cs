using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;
        

        public static List<Movie> All {
            get
            {
                if (movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return movies;
            }
        }
        /*
        public static List<Movie> SearchAndFilter(string searchString, List<string> rating)
        {
            //case 0: no string and ratings to search
            if (searchString == null && rating.Count == 0) return All;

            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                //Case 1: search string and ratings
                if (searchString != null && rating.Count > 0)
                {
                    if (movie.Title != null
                        && movie.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
                        && rating.Contains(movie.MPAA_Rating))
                    {

                    }
                }

                //case 2: search string only
                else if (searchString != null)
                {
                    if (movie.Title != null && movie.Title.Contains(searchString, StringComparison.InvariantCultureIgnoreCase))
                    {
                        results.Add(movie);
                    }
                }
                //case 3: search ratings only
                else if (rating.Count > 0)
                {
                    if (rating.Contains(movie.MPAA_Rating))
                    {
                        results.Add(movie);
                    }
                }

            }
            return results;
        }
        */
        public static List<Movie> Search(List<Movie> movies, string term)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Title.Contains(term, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(movie);
                }

            }
            return results;
        }

        public static List<Movie> FilterByMPAA(List<Movie> movies, List<string> mpaa)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (mpaa.Contains(movie.MPAA_Rating))
                {
                    results.Add(movie);
                }
            }

            return results;
        }

        public static List<Movie> FilterByMinIMBD(List<Movie> movies, float minIMBD)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating != null && movie.IMDB_Rating >= minIMBD)
                {
                    results.Add(movie);
                }
            }

            return results;
        }

        public static List<Movie> FilterByMaxIMBD(List<Movie> movies, float maxIMBD)
        {
            List<Movie> results = new List<Movie>();

            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating != null && movie.IMDB_Rating <= maxIMBD)
                {
                    results.Add(movie);
                }
            }

            return results;
        }
    }
}
