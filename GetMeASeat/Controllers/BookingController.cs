using GetMeASeat.Contracts;
using GetMeASeat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GetMeASeat.Controllers
{
    public class BookingController : ApiController
    {
        static readonly IBooking repo = new Repository();
        
        [HttpGet]
        public IEnumerable<Movies> GetMovies()
        {
            return repo.GetMovies();
        }
        [HttpGet]
        public Movies GetMovie( int id )
        {
            return repo.GetMovie(id);
        }
        [HttpGet]
        public Theatre GetTheatre(int id)
        {
            return repo.GetTheatre(id);
        }
        [HttpGet]
        public IEnumerable<Theatre> GetTheatres()
        {
            return repo.GetTheatres();
        }
        [HttpGet]
        public bool[] GetAvailableSeats(int Showid, DateTime TimeStamp)
        {
            return repo.GetAvailableSeats(Showid,TimeStamp);
        }
        [HttpGet]
        bool IsSeatAvailable(int ShowId, DateTime DateofShow, int SeatStart, int SeatEnd)
        {
            return repo.IsSeatAvailable(ShowId, DateofShow, SeatStart, SeatEnd);
        }
        [HttpGet]
        public MovieinTheatre GetShowDetails(int ShowId)
        {
            return repo.GetShowDetails(ShowId);
        }
        [HttpGet]
        public IEnumerable<MovieinTheatre> GetShowsDetails()
        {
            return repo.GetShowsDetails();
        }
        [HttpGet]
        public int GetShowId(int ShowTimeId, int TheatreId, int MovieId)
        {
            return repo.GetShowId(ShowTimeId, TheatreId, MovieId);
        }
        [HttpGet]
        public ShowTiming GetShowTiming(int id)
        {
            return repo.GetShowTiming(id);
        }
        [HttpGet]
        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return repo.GetShowTimings();
        }
        [HttpGet]
        public void DecreaseActiveUsers(int ShowId, DateTime DateofShow)
        {
            repo.DecreaseActiveUsers(ShowId, DateofShow);
        }
        [HttpGet]
        public void Notify(string EmailId, int ShowId, DateTime DateofShow, int SeatStart, int SeatEnd, string Messaage, float Price)
        {
            repo.Notify(EmailId, ShowId, DateofShow, SeatStart, SeatEnd, Messaage, Price);
        }
        [HttpGet]
        public float SurgePricing(int ShowID, DateTime DateofShow, int SeatStart, int SeatEnd, string UId)
        {
            return repo.SurgePricing(ShowID, DateofShow, SeatStart, SeatEnd, UId);
        }
        [HttpGet]
        public bool BookTickets(DateTime DateofShow, int ShowId, string UId, DateTime DateOfBooking, int NoofTickets, int SeatStart, int SeatEnd, float Price)
        {
            return repo.BookTickets(DateofShow, ShowId, UId, DateOfBooking, NoofTickets, SeatStart, SeatEnd, Price);
        }

    }
}
