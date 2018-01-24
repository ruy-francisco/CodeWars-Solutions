using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanViewAll.Classes
{
    public static class MovieChecker
    {
        public static bool CanViewAll(string [] inputMovies)
        {
            DateTime movieSchedule1;
            DateTime movieSchedule2;

            for (int i = 0; i < inputMovies.Length - 1; i++)
            {
                movieSchedule1 = inputMovies[i].GetMovieEndDateTime();
                movieSchedule2 = inputMovies[i + 1].GetMovieStartDateTime();

                if (movieSchedule1.OverlapedBy(movieSchedule2))
                    return false;
            }

            return true;
        }

        public static bool OverlapedBy(this DateTime currentMovieSchedule, DateTime otherMovieSchedule) => otherMovieSchedule < currentMovieSchedule;

        public static DateTime GetMovieStartDateTime(this string currentStringDateAndTime)
        {
            string[] splitedDateAndTime = currentStringDateAndTime.Split(' ');

            string strDate = splitedDateAndTime[0].Trim();
            string[] splitedDate = strDate.Split('/');

            string strStartTime = splitedDateAndTime[1].Split('-')[0].Trim();
            string[] splitedStartTime = strStartTime.Split(':');

            return new DateTime(int.Parse(splitedDate[2]), int.Parse(splitedDate[1]), int.Parse(splitedDate[0]), int.Parse(splitedStartTime[0]), int.Parse(splitedStartTime[1]), 0);
        }

        public static DateTime GetMovieEndDateTime(this string currentStringDateAndTime)
        {
            string[] splitedDateAndTime = currentStringDateAndTime.Split(' ');

            string strDate = splitedDateAndTime[0].Trim();
            string[] splitedDate = strDate.Split('/');

            string strEndTime = splitedDateAndTime[1].Split('-')[1].Trim();
            string[] splitedEndTime = strEndTime.Split(':');

            return new DateTime(int.Parse(splitedDate[2]), int.Parse(splitedDate[1]), int.Parse(splitedDate[0]), int.Parse(splitedEndTime[0]), int.Parse(splitedEndTime[1]), 0);
        }
    }
}
