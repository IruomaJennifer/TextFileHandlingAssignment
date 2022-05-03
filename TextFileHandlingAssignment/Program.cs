
// See https://aka.ms/new-console-template for more information

using TextFileHandlingAssignment;

//Writing to the text files
//Assignment Model 3
var assignment3 = new List<AssignmentModel3>();
assignment3.Add(new AssignmentModel3 { Id = 301, AssignmentName = "Text File Writing", AssignmentLocation = "Assignments" });
assignment3.Add(new AssignmentModel3 { Id = 302, AssignmentName = "Text File Reading", AssignmentLocation = "Assignments" });
assignment3.Add(new AssignmentModel3 { Id = 303, AssignmentName = "Exception Handling", AssignmentLocation = "Assignments" });
var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
File.WriteAllText(Path.Combine(path,"AssignmentModel3.csv"), "Id,Assignment Name,Assignment Location\n");
File.AppendAllText(Path.Combine(path, "AssignmentModel3.csv"), $"{assignment3[0].Id},{assignment3[0].AssignmentName},{assignment3[0].AssignmentLocation}\n" +
    $"{assignment3[1].Id},{assignment3[1].AssignmentName},{assignment3[1].AssignmentLocation}\n{assignment3[2].Id},{assignment3[2].AssignmentName},{assignment3[2].AssignmentLocation}\n");

//Assignment Model 2
var assignment2 = new List<AssignmentModel2>();
assignment2.Add(new AssignmentModel2 { Id = 201, AssignmentName = "Methods", AssignmentLocation = "Source", AssignmentModel3 = assignment3[0] });
assignment2.Add(new AssignmentModel2 { Id = 202, AssignmentName = "String Manipulation", AssignmentLocation = "Source", AssignmentModel3 = assignment3[1] });
assignment2.Add(new AssignmentModel2 { Id = 203, AssignmentName = "Variables", AssignmentLocation = "Source", AssignmentModel3 = assignment3[2] });
File.WriteAllText(Path.Combine(path, "AssignmentModel2.csv"),"Id,Assignment Name,Assignment Location,Assignment Model 3\n");
File.AppendAllText(Path.Combine(path, "AssignmentModel2.csv"),$"{assignment2[0].Id},{assignment2[0].AssignmentName},{assignment2[0].AssignmentLocation},{assignment2[0].AssignmentModel3.Id}\n" +
    $"{assignment2[1].Id},{assignment2[1].AssignmentName},{assignment2[1].AssignmentLocation},{assignment2[1].AssignmentModel3.Id}\n{assignment2[2].Id},{assignment2[2].AssignmentName}," +
    $"{assignment2[2].AssignmentLocation},{assignment2[2].AssignmentModel3.Id}\n");

//Assignment Model 1
var assignment1 = new List<AssignmentModel1>();
assignment1.Add(new AssignmentModel1 { Id = 101, AssignmentName = "Recursion", AssignmentLocation = "Documents", AssignmentModel2 = assignment2[0] });
assignment1.Add(new AssignmentModel1 { Id = 102, AssignmentName = "Object Oriented Programming", AssignmentLocation = "Documents", AssignmentModel2 = assignment2[1] });
assignment1.Add(new AssignmentModel1 { Id = 103, AssignmentName = "Standard Input and Output", AssignmentLocation = "Documents", AssignmentModel2 = assignment2[2] });
File.WriteAllText(Path.Combine(path, "AssignmentModel1.csv"), "Id,Assignment Name,Assignment Location, Assignment Model 2\n");
File.AppendAllText(Path.Combine(path, "AssignmentModel1.csv"), $"{assignment1[0].Id},{assignment1[0].AssignmentName},{assignment1[0].AssignmentLocation},{assignment1[0].AssignmentModel2.Id}\n" +
    $"{assignment1[1].Id},{assignment1[1].AssignmentName},{assignment1[1].AssignmentLocation},{assignment1[1].AssignmentModel2.Id}\n{assignment1[2].Id},{assignment1[2].AssignmentName}," +
    $"{assignment1[2].AssignmentLocation},{assignment1[2].AssignmentModel2.Id}\n");


//Reading From the Text Files
//Assignment Model 3
var assignment3_new = new List<AssignmentModel3>();
var csv_assignment3_text = File.ReadAllLines(Path.Combine(path, "AssignmentModel3.csv"));
foreach (var item in csv_assignment3_text.Skip(1))
{
    var items = item.Split(',');
    assignment3_new.Add(new AssignmentModel3
    {
        Id = int.Parse(items[0]),
        AssignmentName = items[1],
        AssignmentLocation = items[2]
    });
}

//Assignment Model 2
int i = 0;
var assignment2_new = new List<AssignmentModel2>();
var csv_assignment2_text = File.ReadAllLines(Path.Combine(path, "AssignmentModel2.csv"));
foreach (var item in csv_assignment2_text.Skip(1))
{
    var items = item.Split(',');
    assignment2_new.Add(new AssignmentModel2
    {
        Id = int.Parse(items[0]),
        AssignmentName = items[1],
        AssignmentLocation = items[2],
        AssignmentModel3 = assignment3_new[i]
    });
    i++;
}

//Assignment Model 1
int j = 0;
var assignment1_new = new List<AssignmentModel1>();
var csv_assignment1_text = File.ReadAllLines(Path.Combine(path, "AssignmentModel1.csv"));
foreach (var item in csv_assignment1_text.Skip(1))
{
    var items = item.Split(',');
    assignment1_new.Add(new AssignmentModel1
    {
        Id = int.Parse(items[0]),
        AssignmentName = items[1],
        AssignmentLocation = items[2],
        AssignmentModel2 = assignment2_new[j]
    });
    j++;
}

//check section
Console.WriteLine(assignment1_new[2].AssignmentModel2.Id);
Console.WriteLine(assignment2_new[2].AssignmentModel3.Id);
Console.WriteLine(assignment3_new[1].Id);