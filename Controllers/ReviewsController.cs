using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Reviews.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private TravelAPIContext _db;

    public ReviewsController(TravelAPIContext db)
    {
      _db = db;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string country,string city, int rating, string reviewDescription) 
    {
      
      string ratingStr = rating.ToString(); 
    
      var query = _db.Reviews.AsQueryable();
      if(country!=null)
      {
        query = query.Where(entry => entry.Country==country);
      }
      else if(city!=null)
      {
        query = query.Where(entry => entry.City==city);
      }
      else if(ratingStr!=null)
      {
        query = query.Where(entry => entry.Rating==rating);
      }
      else if(reviewDescription!=null)
      {
        query = query.Where(entry => entry.ReviewDescription==reviewDescription);
      }
    
      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody] Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
    }
    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id) 
    {
      var foundReview = _db.Reviews.FirstOrDefault(row =>row.ReviewId==id);
    
      return foundReview;
    }


    // PUT api/Review/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
      review.ReviewId = id;
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
    }

    // DELETE api/Review/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      _db.Reviews.Remove(reviewToDelete);
      _db.SaveChanges();
    }
  }
}


    // [HttpGet]
    // public ActionResult<Review> Get(int id) 
    // {
    //   Review foundReview = _db.Reviews.FirstOrDefault(row =>row.ReviewId==id);
    
    //   return foundReview;
    // }

    //  [HttpGet]
    // public ActionResult <Review> Country (string country) 
    // {
      
    //   Review review = _db.Reviews.FirstOrDefault(row => row.Country==country);
    //   return review; 
    // }
    // GET api/Review
    // [HttpGet]
    // public ActionResult<IEnumerable<Review>> Get(string country, string city, int rating, string reviewDescription)
    // {
    //   var query = _db.Reviews.AsQueryable();

    //   if (country != null)
    //   {
    //     query = query.Where(entry => entry.Country == country);
    //   }

    //   if (city != null)
    //   {
    //     query = query.Where(entry => entry.City == city);
    //   }

    //   if (rating != null)
    //   {
    //     query = query.Where(entry => entry.Rating == rating);
    //   }

    //   if (reviewDescription != null)
    //   {
    //     query = query.Where(entry => entry.ReviewDescription == reviewDescription);
    //   }

    //   return query.ToList();
    // }

    // POST api/Review