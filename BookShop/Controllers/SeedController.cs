using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookShop.Controllers
{
    public class SeedController: Controller
    {
        private readonly DataContext _context;

        public SeedController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Count = _context.Books.Count();
            return View(_context.Books.Include(x => x.Category).OrderBy(x => x.Id).Take(20));
        }

        [HttpPost]
        public IActionResult CreateSeedData(int count)
        {
            ClearData();
            if(count > 0)
            {
                _context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
                _context.Database.ExecuteSqlRaw("DROP PROCEDURE IF EXISTS CreateSeedData");
                _context.Database.ExecuteSqlRaw($@"
                    CREATE PROCEDURE CreateSeedData
	                    @RowCount decimal
                    AS
	                  BEGIN
	                  SET NOCOUNT ON
                      DECLARE @i INT = 1;
	                  DECLARE @catId BIGINT;
	                  DECLARE @CatCount INT = @RowCount / 10;
	                  DECLARE @pprice DECIMAL(5,2);
	                  DECLARE @rprice DECIMAL(5,2);
                      DECLARE @ddate DATETIME = GETDATE();
	                  BEGIN TRANSACTION
		                WHILE @i <= @CatCount
			              BEGIN
				            INSERT INTO Categories (Name, Description)
				            VALUES (CONCAT('Category-', @i), 
                                             'Test Data Category');
				            SET @catId = SCOPE_IDENTITY();
				            DECLARE @j INT = 1;
				            WHILE @j <= 10
					        BEGIN
						   SET @pprice = RAND()*(500-5+1);
						   SET @rprice = (RAND() * @pprice) 
                                                   + @pprice;
                        INSERT INTO [dbo].[Books]
						   ([Title]
                           ,[Price]
                           ,[RetailPrice]
                           ,[CategoryId]
                           ,[PublishedOn]
                            )
						   VALUES (CONCAT('Book', @i, '-', @j), @pprice, @rprice, @catId, @ddate)
						   SET @j = @j + 1
					          END
		                    SET @i = @i + 1
		                    END
	                    COMMIT
                    END");

                _context.Database.BeginTransaction();
                _context.Database.ExecuteSqlRaw($"EXEC CreateSeedData @RowCount = {count}");
                _context.Database.CommitTransaction();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ClearData()
        {
            _context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
            _context.Database.BeginTransaction();
            _context.Database.ExecuteSqlRaw("DELETE FROM Orders");
            _context.Database.ExecuteSqlRaw("DELETE FROM Categories");
            _context.Database.CommitTransaction();
            return RedirectToAction(nameof(Index));
        }
    }
}
