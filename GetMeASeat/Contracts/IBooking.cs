using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetMeASeat.Models;

namespace GetMeASeat.Contracts
{
    public interface IBooking
    {
        IEnumerable<Movies> GetMovies();
        Movies GetMovie(int id);
        IEnumerable<Theatre> GetTheatres();
        Theatre GetTheatre(int id);
        IEnumerable<ShowTiming> GetShowTimings();
        MovieinTheatre GetShowDetails(int ShowId);
        IEnumerable<MovieinTheatre> GetShowsDetails();
        ShowTiming GetShowTiming(int id);
        bool IsSeatAvailable(int ShowId, DateTime DateofShow, int SeatStart, int SeatEnd);
        bool[] GetAvailableSeats(int ShowID, DateTime DateofShowing);
        float SurgePricing(int ShowID, DateTime DateofShowing, int SeatStart, int SeatEnd, string UId);
        void Notify(string EmailId, int ShowId, DateTime DateofShowing, int SeatStart, int SeatEnd, string Message, float Price);
        bool BookTickets(DateTime DateofShowing ,int ShowId, string UId, DateTime DateOfBooking, int NoofTickets, int SeatStart, int SeatEnd, float Price);
        void DecreaseActiveUsers(int ShowId, DateTime DateofShow);
        int GetShowId(int ShowTimeId, int TheatreId, int MovieId);
    }
}
