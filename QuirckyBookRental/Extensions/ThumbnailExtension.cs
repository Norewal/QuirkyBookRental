﻿using QuirkyBookRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Extensions
{
    public static class ThumbnailExtensions
    {
        //it will return a list of thumbnail
        public static IEnumerable<ThumbnailModel> GetBookThumbnail(this List<ThumbnailModel> thumbnails, ApplicationDbContext db = null, string search = null)
        {
            try
            {
                if (db == null) db = ApplicationDbContext.Create();

                thumbnails = (from b in db.Books
                              select new ThumbnailModel
                              {
                                  BookId = b.Id,
                                  Title = b.Title,
                                  Description = b.Description,
                                  ImageUrl = b.ImageUrl,
                                  Link = "/BookDetail/Index/" + b.Id,
                              }).ToList(); //converting the output into a list

                // search functionality
                if (search != null)
                {
                    return thumbnails.Where(t => t.Title.ToLower().Contains(search.ToLower())).OrderBy(t => t.Title);
                }
            }
            catch (Exception ex)
            {

            }
            return thumbnails.OrderBy(b => b.Title);
             
        }
    }
}