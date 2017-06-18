using GetMeASeat.Contracts;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;


namespace GetMeASeat.Models
{
    public class Repository : IBooking
    {
        #region ListVariables

        public List<Movies> MoviesList = new List<Movies>();
        public List<Theatre> TheatreList = new List<Theatre>();
        public List<ShowTiming> ShowTimingsList = new List<ShowTiming>();
        public List<TicketRate> TicketRateList = new List<TicketRate>();
        public List<MovieinTheatre> MovieinTheatreList = new List<MovieinTheatre>();
        public List<Booking> BookingList = new List<Booking>();
        public List<UserSelectedSeats> USSList = new List<UserSelectedSeats>();
        public List<LogViewer> LogViewerList = new List<LogViewer>();
        public bool[] Seats = new bool[50];

        #endregion

        public Repository()
        {
            for(int jj = 0; jj < 50; jj++)
            {
                Seats[jj] = true;
            }
            Movies Movie1 = new Movies
            {
                Movie_id = 1,
                Name = "Baahubali, The Conclusion",
                Language = "Telugu",
                ReleaseDate = new DateTime(2017, 04, 27),
                MovieLength = "2.56"
            };
            Movies Movie2 = new Movies
            {
                Movie_id = 2,
                Name = "The Mummy",
                Language = "English",
                ReleaseDate = new DateTime(2017, 05, 27),
                MovieLength = "1.86"
            };
            MoviesList.Add(Movie1);
            MoviesList.Add(Movie2);
            Theatre Theatre1 = new Theatre
            {
                Theatre_id = 1,
                Name = "Inox",
                City_id = 1,
            };
            Theatre Theatre2 = new Theatre
            {
                Theatre_id = 2,
                Name = "Imax",
                City_id = 1,
            };
            TheatreList.Add(Theatre1);
            TheatreList.Add(Theatre2);
            ShowTiming MorningShow = new ShowTiming
            {
                ShowTimeId = 1,
                Time = "11"
            };
            ShowTiming Matinee = new ShowTiming
            {
                ShowTimeId = 2,
                Time = "14"
            };
            ShowTiming FirstShow = new ShowTiming
            {
                ShowTimeId = 3,
                Time = "17"
            };
            ShowTiming SecondShow = new ShowTiming
            {
                ShowTimeId = 4,
                Time = "20"
            };
            ShowTimingsList.Add(MorningShow);
            ShowTimingsList.Add(Matinee);
            ShowTimingsList.Add(FirstShow);
            ShowTimingsList.Add(SecondShow);
            TicketRate TheatrePrice1 = new TicketRate
            {
                Rate_id = 1,
                Theatre_id = 1,
                Price = 100
            };
            TicketRate TheatrePrice2 = new TicketRate
            {
                Rate_id = 2,
                Theatre_id = 2,
                Price = 100
            };
            TicketRateList.Add(TheatrePrice1);
            TicketRateList.Add(TheatrePrice2);
            MovieinTheatre MovieinTheatre1Show1 = new MovieinTheatre
            {
                Show_id = 1,
                Movie_id = 1,
                Theatre_id = 1,
                TotalSeats = 50,
                ShowTimeId = 1,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatre MovieinTheatre1Show2 = new MovieinTheatre
            {
                Show_id = 2,
                Movie_id = 1,
                Theatre_id = 1,
                TotalSeats = 50,
                ShowTimeId = 2,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatre MovieinTheatre1Show3 = new MovieinTheatre
            {
                Show_id = 3,
                Movie_id = 1,
                Theatre_id = 1,
                TotalSeats = 50,
                ShowTimeId = 3,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatre MovieinTheatre1Show4 = new MovieinTheatre
            {
                Show_id = 4,
                Movie_id = 1,
                Theatre_id = 1,
                TotalSeats = 50,
                ShowTimeId = 4,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatre MovieinTheatre2Show1 = new MovieinTheatre
            {
                Show_id = 5,
                Movie_id = 2,
                Theatre_id = 2,
                TotalSeats = 50,
                ShowTimeId = 1,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatre MovieinTheatre2Show2 = new MovieinTheatre
            {
                Show_id = 6,
                Movie_id = 2,
                Theatre_id = 2,
                TotalSeats = 50,
                ShowTimeId = 2,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatre MovieinTheatre2Show3 = new MovieinTheatre
            {
                Show_id = 7,
                Movie_id = 2,
                Theatre_id = 2,
                TotalSeats = 50,
                ShowTimeId = 3,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatre MovieinTheatre2Show4 = new MovieinTheatre
            {
                Show_id = 8,
                Movie_id = 2,
                Theatre_id = 2,
                TotalSeats = 50,
                ShowTimeId = 4,
                DateStart = new DateTime(2017, 04, 27),
                DateEnd = new DateTime(2017, 07, 27),
            };
            MovieinTheatreList.Add(MovieinTheatre1Show1);
            MovieinTheatreList.Add(MovieinTheatre1Show2);
            MovieinTheatreList.Add(MovieinTheatre1Show3);
            MovieinTheatreList.Add(MovieinTheatre1Show4);
            MovieinTheatreList.Add(MovieinTheatre2Show1);
            MovieinTheatreList.Add(MovieinTheatre2Show2);
            MovieinTheatreList.Add(MovieinTheatre2Show3);
            MovieinTheatreList.Add(MovieinTheatre2Show4);
        }
        
        public MovieinTheatre GetShowDetails(int ShowId)
        {
            return MovieinTheatreList.Find(s => s.Show_id == ShowId);
        }

        public IEnumerable<MovieinTheatre> GetShowsDetails()
        {
            return MovieinTheatreList;
        }

        public bool[] GetAvailableSeats(int ShowID, DateTime DateofShow)
        {
            bool[] Seats = new bool[51];
            for (int jj = 1; jj < 51; jj++)
            {
                Seats[jj] = true;
            }
            LogViewer LocalLog = new LogViewer();
            LocalLog.TimeStamp = DateTime.Now;
            LocalLog.ActiveViewers++;
            LocalLog.DateofShow = DateofShow;
            LocalLog.TotalViewers++;
            LocalLog.ShowId = ShowID;
            if (LogViewerList.Find(s => s.ShowId == ShowID && s.DateofShow == DateofShow) != null)
            {
                LogViewerList.Find(s => s.ShowId == ShowID && s.DateofShow == DateofShow).ActiveViewers++;
                LogViewerList.Find(s => s.ShowId == ShowID && s.DateofShow == DateofShow).TotalViewers++;
            }
            else
            {
                LogViewerList.Add(LocalLog);
            }

         
            List<Booking> BookingsForShow = new List<Booking>();

            BookingsForShow.AddRange(BookingList.FindAll(i => i.Show_id == ShowID && i.DateofShow == DateofShow));

            var index = 0;
            
            foreach (var i in BookingsForShow)
            {
                if (i.SeatStart == i.SeatEnd)
                {
                    Seats[i.SeatStart] = false;
                }
                else if (i.SeatStart <= i.SeatEnd)
                {
                    for (index = i.SeatStart; index <= i.SeatEnd; index++)
                    {
                        Seats[index] = false;
                    }
                }
            }
            
            return Seats;

        }

        public Movies GetMovie(int id)
        {
            return MoviesList.Find(s => s.Movie_id == id);
        }

        public IEnumerable<Movies> GetMovies()
        {
            return MoviesList;
        }

        public ShowTiming GetShowTiming(int id)
        {
            return ShowTimingsList.Find(s => s.ShowTimeId == id);
        }

        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return ShowTimingsList;
        }

        public Theatre GetTheatre(int id)
        {
            return TheatreList.Find(s => s.Theatre_id == id);
        }

        public int GetShowId(int ShowTimeId, int TheatreId, int MovieId)
        {
            return MovieinTheatreList.Find(s => s.ShowTimeId == ShowTimeId && s.Movie_id == MovieId && s.Theatre_id == TheatreId).Show_id;
        }

        public IEnumerable<Theatre> GetTheatres()
        {
            return TheatreList;
        }

        public bool IsSeatAvailable(int ShowId, DateTime DateofShow, int SeatStart, int SeatEnd)
        {
            var local = BookingList.FindAll(s => s.Show_id == ShowId && s.DateofShow == DateofShow );
            foreach (var i in local)
            {
                if (SeatStart>=i.SeatStart && SeatStart<=i.SeatEnd)
                {
                    return false;
                }
            }
            return true; ;
        }

        public void Notify(string EmailId, int ShowId, DateTime DateofShow, int SeatStart, int SeatEnd, string Message, float Price)
        {
            //From Address  
            string FromAddress = "MovieTicket@GetMeaSeat.com";
            string FromAdressTitle = "Get Me a Seat";
            //To Address  
            string ToAddress = EmailId;
            string ToAdressTitle = "Get Me a Seat";
            string Subject = "Ticket Booking";
            string BodyContent;
            if (SeatStart == -1)
            {
                Subject = "Prices are Down now.";
                BodyContent = Message + " you can get a Ticket @  " + Price;
            }
            else
            {
                Subject = "Ticket Booking";
                if (SeatEnd == SeatStart)
                {
                    BodyContent = Message + " Seat: " + SeatStart  + " @Total Price: " + Price;
                }
                else BodyContent = Message + " Seats " + SeatStart + " : " + SeatEnd + " @ Total Price: " + Price;
            }
            

            //Smtp Server  
            string SmtpServer = "smtp.honeywell.com";
            //Smtp Port Number  
            int SmtpPortNumber = 25;

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
            mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
            mimeMessage.Subject = Subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = BodyContent

            };

            using (var client = new SmtpClient())
            {

                client.Connect(SmtpServer, SmtpPortNumber, false);
                // Note: only needed if the SMTP server requires authentication  
                // Error 5.5.1 Authentication   
                //client.Authenticate("from email id", "pass");
                client.Send(mimeMessage);

                client.Disconnect(true);

            }
        }

        public float SurgePricing(int ShowID, DateTime DateofShow, int SeatStart, int SeatEnd, string UId)
        {
            float Multiplier = 1;

            var local = new UserSelectedSeats();
            if (USSList.Count > 0)
            {
                local.Id = USSList[USSList.Count - 1].Id + 1;
            }
            else local.Id = 1;
            local.DateofShow = DateofShow;
            local.PaymentStatus = "Pending";
            local.SeatEnd = SeatEnd;
            local.SeatStart = SeatStart;
            local.ShowId = ShowID;
            local.UId = UId;
            local.TimeStamp = DateTime.Now;
            USSList.Add(local);
            float Criteria1;

            //SurgePricing
            if (LogViewerList.FindAll(s => s.ShowId == ShowID && s.DateofShow == DateofShow).Count > 15)
            {
                Criteria1 = float.Parse(LogViewerList.Find(s => s.ShowId == ShowID && s.DateofShow == DateofShow).ViewersBooked.ToString()) / float.Parse(LogViewerList.Find(s => s.ShowId == ShowID && s.DateofShow == DateofShow).TotalViewers.ToString());
            }
            else Criteria1 = 2f;
            float Criteria2 = float.Parse(LogViewerList.Find(s => s.ShowId == ShowID && s.DateofShow == DateofShow).ActiveViewers.ToString()) / float.Parse(GetAvailableSeats(ShowID, DateofShow).Length.ToString());
            float Criteria3 = USSList.FindAll(s => s.DateofShow == DateofShow && s.ShowId == ShowID && s.TimeStamp > DateTime.Now - TimeSpan.FromSeconds(5)).Count;
            if (Criteria1 < 0.4f)
            {
                Multiplier = 1f - (0.5f - Criteria1);
            }
            else if (Criteria1 >= 0.4f )
            {
                Multiplier = (Criteria1 + Criteria2) * 0.39123f + (Criteria3)*0.75f;
            }
           
            if (Multiplier < 0.5f) Multiplier = 0.5f;
            else if (Multiplier > 2.5f) Multiplier = 2.5f;

            if (Multiplier < 1.0f)
            {
                var locallist = USSList.FindAll(s => s.ShowId == ShowID && s.DateofShow == DateofShow && s.UId != UId);
                foreach(var i in locallist)
                {
                    Notify(i.UId, ShowID, DateofShow, -1, -1, "Prices are down Now", Multiplier * 100);
                }
            }
            return Multiplier;
        }

        public void DecreaseActiveUsers(int ShowId, DateTime DateofShow)
        {
            var local = LogViewerList.Find(s => s.ShowId == ShowId && s.DateofShow == DateofShow);
            local.ActiveViewers--;
        }

        public bool BookTickets(DateTime DateofShow, int ShowId, string UId, DateTime DateOfBooking, int NoofTickets, int SeatStart, int SeatEnd, float Price)
        {
            if(IsSeatAvailable(ShowId, DateofShow, SeatStart, SeatEnd))
            {
                
                LogViewerList.Find(s => s.ShowId == ShowId && s.DateofShow == DateofShow).ViewersBooked++;
                var LocalBooking = new Booking();
                if (BookingList.Count > 0)
                {
                    LocalBooking.Booking_id = BookingList[BookingList.Count - 1].Booking_id + 1;
                }
                else LocalBooking.Booking_id = 1;
                LocalBooking.AmountPaid = Price;
                LocalBooking.DateofBooking = DateOfBooking;
                LocalBooking.DateofShow = DateofShow;
                LocalBooking.NoofTickets = NoofTickets;
                LocalBooking.SeatEnd = SeatEnd;
                LocalBooking.SeatStart = SeatStart;
                LocalBooking.Uid = UId;
                LocalBooking.Show_id = ShowId;
                LocalBooking.USSID = USSList.Find(s => s.UId == UId && s.ShowId == ShowId && s.DateofShow == DateofShow).Id;
                BookingList.Add(LocalBooking);
                DecreaseActiveUsers(ShowId, DateofShow);
                Notify(UId, ShowId, DateofShow, SeatStart, SeatEnd, "Hi, Your Ticket was Booked", Price);
                return true;
            }
            return false;
        }
    }
}