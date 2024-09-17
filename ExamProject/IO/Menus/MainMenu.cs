using ExamProject.EfPersistence;
using ExamProject.IO.Interfaces;

namespace ExamProject.IO.Menus;

public class MainMenu(EfDataContext context, IUi ui) : MenuStructure(ui)
{
    protected override void AddMenuItems()
    {
        MenuItems.Add("Show Animal Menu", ShowAnimalMenu);
        MenuItems.Add("Show Zoo Menu", ShowZooMenu);
        MenuItems.Add("Show Section Menu", ShowSectionMenu);
        MenuItems.Add("Show Ticket Menu", ShowTicketMenu);
        MenuItems.Add("Exam Report Menu", ShowReportMenu);
        // MenuItems.Add("Show Cost Menu", ShowCostMenu);

    }
    protected override string ExitMessageMenu { get; } = "Exit!";
    private void ShowReportMenu()
    {
        new ReportMenu(context , ui).Show();
    }
    private void ShowTicketMenu()
    {
        new TicketMenu(ui, context).Show();
    }

    private void ShowSectionMenu()
    {
        new SectionMenu(ui, context).Show();
    }

    private void ShowZooMenu()
    {
        new ZooMenu(ui, context).Show();
    }
    private void ShowAnimalMenu()
    {
        new AnimalMenu(ui, context).Show();
    }
}