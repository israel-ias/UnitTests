
using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections;

namespace Bongo.DataAccess;
public class StudyRoomBookingRepositoryTests
{
    private StudyRoomBooking studyRoomBooking_One;
    private StudyRoomBooking studyRoomBooking_Two;
    private DbContextOptions<ApplicationDbContext> _options;

    [SetUp]
    public void SetUp()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "temp_bongo").Options;
    }

    public StudyRoomBookingRepositoryTests()
    {
        studyRoomBooking_One = new StudyRoomBooking()
        {
            FirstName = "John",
            LastName = "Doe",
            Date = new DateTime(2022, 10, 2),
            Email = "jdoe@email.com",
            BookingId = 9,
            StudyRoomId = 1
        };

        studyRoomBooking_Two = new StudyRoomBooking()
        {
            FirstName = "John",
            LastName = "Doe",
            Date = new DateTime(2022, 10, 2),
            Email = "jdoe@email.com",
            BookingId = 12,
            StudyRoomId = 2
        };
    }

    [Test]
    public void SaveBooking_Booking_CheckTheValuesFromDatabase()
    {
        using var context = new ApplicationDbContext(_options);
        var repository = new StudyRoomBookingRepository(context);
        repository.Book(studyRoomBooking_One);


        using var ctx = new ApplicationDbContext(_options);
        var bookingFromDb = ctx.StudyRoomBookings.FirstOrDefault(u => u.BookingId == 9);
        Assert.AreEqual(studyRoomBooking_One.FirstName, bookingFromDb.FirstName);
        Assert.AreEqual(studyRoomBooking_One.LastName, bookingFromDb.LastName);
        Assert.AreEqual(studyRoomBooking_One.Date, bookingFromDb.Date);
        Assert.AreEqual(studyRoomBooking_One.Email, bookingFromDb.Email);
        Assert.AreEqual(studyRoomBooking_One.BookingId, bookingFromDb.BookingId);
        Assert.AreEqual(studyRoomBooking_One.StudyRoomId, bookingFromDb.StudyRoomId);
        
    }

    [Test]
    public void GetAllBooking_BookingOneAndTwo_CheckTheValuesFromDatabase()
    {
        var expectedResult = new List<StudyRoomBooking>{ studyRoomBooking_One, studyRoomBooking_Two};
       

        using var context = new ApplicationDbContext(_options);
        context.Database.EnsureDeleted();
        var repository = new StudyRoomBookingRepository(context);
        repository.Book(studyRoomBooking_One);
        repository.Book(studyRoomBooking_Two);

        List<StudyRoomBooking> actualList;
        using var ctx = new ApplicationDbContext(_options);
        var rep = new StudyRoomBookingRepository(ctx);
        actualList = rep.GetAll(null).ToList();


        CollectionAssert.AreEqual(expectedResult, actualList, new BookingCompare());
    }

    
}


public class BookingCompare : IComparer
{
    public int Compare(object x, object y)
    {
        var booking1 = (StudyRoomBooking)x;
        var booking2 = (StudyRoomBooking)y;
        if (booking1.BookingId != booking2.BookingId)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
