using ExamProject.EfPersistence;
using ExamProject.IO;
using ExamProject.IO.Menus;
using Microsoft.EntityFrameworkCore;

var consoleUi = new ConsoleUi();
var dbContext = new EfDataContext();
var mainMenu = new MainMenu(dbContext, consoleUi);
mainMenu.Show();
