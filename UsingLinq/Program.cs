










using System.Text.RegularExpressions;
using UsingLinq;

//Restriction();
//Ordering();
//Element();
//Projection();
//Projection2Collections();
//Set();
//Conversion();
//Generation();
//Quandtifiers();
Aggregats();

void Aggregats()
{
    // SUM COUNT MIN MAX AVERAGE
    Students[] students = {
        new Students { firstName = "Rachid", age = 19 } ,
        new Students { firstName = "Pantélis", age= 20 } ,
        new Students { firstName = "Igor", age = 23} ,
        new Students { firstName = "Anas", age = 20} ,
        new Students { firstName = "Jim", age = 14} ,
        new Students { firstName = "Carolina", age =18},
        new Students { firstName = "Pedro", age=16},
        new Students { firstName = "David", age= 14}
    };
    var ageMax = students.Max(student => student.age);
    Console.WriteLine(ageMax);
    var ageMin = students.Min(student => student.age);
    Console.WriteLine(ageMin);
    double ageMoyen = students.Average(s => s.age);
    Console.WriteLine(ageMoyen);
    var studentAgeMin = students.Where(stud => stud.age == students.Min(x => x.age)).First();         
    Console.WriteLine(studentAgeMin);
    var studentAgeMax = students.Where(stud => stud.age == students.Max(x => x.age)).First();
    Console.WriteLine(studentAgeMax);
    int NbrStudent = students.Select(s => s).Count();
    Console.WriteLine(NbrStudent);
    int sommeAge = students.Sum(s => s.age);
    Console.WriteLine(sommeAge);
    
    
}

void Quandtifiers()
{
    Students[] students = {
        new Students { firstName = "Rachid", age = 19 } ,
        new Students { firstName = "Pantélis", age= 20 } ,
        new Students { firstName = "Igor", age = 23} ,
        new Students { firstName = "Anas", age = 20} ,
        new Students { firstName = "Jim", age = 14} ,
        new Students { firstName = "Carolina", age =18},
        new Students { firstName = "Pedro", age=16},
        new Students { firstName = "David", age= 14}
    };
    var result = students.All(student => student.age < 25);
    Console.WriteLine(result);
    result = students.All(student => student.age < 20);
    Console.WriteLine(result);
    result = students.Any(student => student.age < 20);
    Console.WriteLine(result);
    result = students.Any(student => student.age > 20);
    Console.WriteLine(result);
    result = students.All(student => student.age.IsEven());
    Console.WriteLine(result);
}

void Generation()
{
    // opérateur Range, Repeat
    var sequenceRange = Enumerable.Range(0, 121).ToArray();
    foreach (var item in sequenceRange)
    {
        Console.WriteLine(item);
    }
    var sequenceRepeat = Enumerable.Repeat(true, 120).ToArray();
    foreach (var item in sequenceRepeat)
    {
        Console.WriteLine(item);
    }
}

void Conversion()
{
    int[] numbersA = { 1, 2, 3, 4, 5, 6, 7 };
    List<int> numbersList = numbersA.ToList();
    Console.WriteLine($"numbersA est du type {numbersA.GetType().Name}");
    Console.WriteLine($"numbersA est du type {numbersList.GetType().Name}");

    Students[] students = {
        new Students { firstName = "Rachid", age = 19 } ,
        new Students { firstName = "Pantélis", age= 20 } ,
        new Students { firstName = "Igor", age = 23} ,
        new Students { firstName = "Anas", age = 20} ,
        new Students { firstName = "Jim", age = 14} ,
        new Students { firstName = "Carolina", age =18},
        new Students { firstName = "Pedro", age=16},
        new Students { firstName = "David", age= 14}
    };
    object[] objects = {"Julien", 31, 5.02, null, "Albert", 'c'};

    var studentsDictionary = students.ToDictionary(x => x.firstName, s => s);
    foreach (var item in studentsDictionary)
    {
        Console.WriteLine($"La clef est : {item.Key} la valeur est : {item.Value.firstName} l'age est : {item.Value.age} ");
    }

    var studentsDic = students
                      .Where(s => s.age.IsEven())
                      .ToDictionary(x => x.firstName, s => s);
    foreach (var item in studentsDic)
    {
        Console.WriteLine($"{item}");
    }

    var sequence = objects.OfType<string>();
    Console.WriteLine(String.Join(", ", sequence));

}

void Set()
{
    int[] numbersA = {1, 2, 3, 4, 5, 6, 7};
    int[] numbersB = { 1, 2, 8, 9, };
    var numbersUnion = numbersA.Union(numbersB);
    Console.WriteLine(string.Join("\n", numbersUnion));
    var numbersConcat = numbersA.Concat(numbersB);
    Console.WriteLine(string.Join("\n", numbersConcat));
    var numbersInter = numbersA.Intersect(numbersB);
    Console.WriteLine(string.Join("\n", numbersInter));
    var numbersExcept = numbersA.Except(numbersB);
    Console.WriteLine(string.Join("\n", numbersExcept));

    IList<Students> students = new List<Students> {
        new Students { firstName = "Rachid", age = 19 } ,
        new Students { firstName = "Pantélis", age= 20 } ,
        new Students { firstName = "Igor", age = 23} ,
        new Students { firstName = "Anas", age = 20} ,
        new Students { firstName = "Jim", age = 14} ,
        new Students { firstName = "Carolina", age =18},
        new Students { firstName = "Pedro", age=16},
        new Students { firstName = "David", age= 14}
    };
    var sequenceAge = students.Select(st => st.age).Distinct().OrderBy(age => age);
    foreach (var age in sequenceAge)
    {
        Console.WriteLine(age);
    }
    Console.WriteLine("Nombre d'ages differents");
    students.Add(new Students { firstName = "Carolinaa", age = 11 });
    int Compteur = sequenceAge.Count();
    Console.WriteLine(Compteur);
}

void Projection2Collections()
{
    int[] numbers = { 1, 3, 5, 7, 9, 0, 2, 4, 6, 8 };
    string[] strings = { "Zero", "Un", "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept", "Huit", "Neuf" };
    var sequence = (numbers.Select(n => new
    {
        Numero = n,
        Lettre = strings[n]

    }));
   
    foreach (var number in sequence)
    {
        Console.WriteLine(number);
    }
    

}

void Projection()
{
    string[] fruits = { "Pomme", "Poire", "Prune", "Ananas", "Banane" };
    var sequence = fruits.Select(f => f.ToUpper()).Where(f => !f.StartsWith("P", StringComparison.CurrentCultureIgnoreCase));
    foreach (var fruit in sequence)
    {
        Console.WriteLine(fruit);
    }
    
    sequence = fruits.Where(f => !f.ToLower().Contains("a")).Select(f => f.ToLower());
    foreach (var fruit in sequence)
    {
        Console.WriteLine(fruit);
    }

    var seq = fruits.Where(fruits => !Regex.IsMatch(fruits, @"a|A"))
            .Select(f => new
            {
              Masjuc = f.ToUpper() ,
              Minusc = f.ToLower(),
              Lenght = f.Length
            });  
    foreach (var fruit in seq)
    {
        Console.WriteLine(fruit);
    } 
}

void Element()
{
    Students[] students = { };
    var student = students.FirstOrDefault();
    Console.WriteLine($"{(student == null ? "Valeur null" : student)}");
    int[] numbers = { 1, 3, 5, 7, 9, 0, 2, 4, 6, 8, 7, 9, 2, 4 };
    int[] empty = { };
    var elmt = numbers.FirstOrDefault();
    Console.WriteLine(elmt);
    elmt = numbers.Last();
    Console.WriteLine(elmt);
    elmt= numbers.ElementAtOrDefault(0);
    Console.WriteLine(elmt);
    var nbrNeuf = numbers.Where(n => n == 9).FirstOrDefault();
    Console.WriteLine(nbrNeuf);
    var nbrSept = numbers.Where(n => n == 7).SingleOrDefault();
    Console.WriteLine(nbrSept);

}

void Ordering()
{
    Students[] students = {
        new Students { firstName = "Rachid", age = 19 } ,
        new Students { firstName = "Pantélis", age= 20 } ,
        new Students { firstName = "Igor", age = 23} ,
        new Students { firstName = "Anas", age = 20} ,
        new Students { firstName = "Jim", age = 14} ,
        new Students { firstName = "Carolina", age =18},
        new Students { firstName = "Pedro", age=16},
        new Students { firstName = "David", age= 14}
    };

    var reverseStudents = students.Reverse();
    foreach (var studenty in reverseStudents)
    {
        Console.WriteLine($"{studenty.firstName} {studenty.age}");
    }
}

static void Restriction()
{
    int[] numbers = { 1, 3, 5, 7, 9, 0, 2, 4, 6, 8 };
    Students[] students = {
        new Students { firstName = "Rachid", age = 19 } ,
        new Students { firstName = "Pantélis", age= 20 } ,
        new Students { firstName = "Igor", age = 23} ,
        new Students { firstName = "Anas", age = 20} ,
        new Students { firstName = "Jim", age = 14} ,
        new Students { firstName = "Carolina", age =18},
        new Students { firstName = "Pedro", age=16},
        new Students { firstName = "David", age= 14}
    };
    Console.WriteLine("Liste des ages moins de 18 ans trié pr prénom");
    var sequenceString = students.Where(student => student.age < 18).OrderBy(student => student.firstName);
    foreach (var studenty in sequenceString)
    {
        Console.WriteLine($"{studenty.firstName} {studenty.age}");
    }
    Console.WriteLine("Liste des age moins de 20 ans et trié par age et puis par prénom");
    sequenceString = students.Where(student => student.age < 20).OrderBy(student => (student.age, student.firstName));
    foreach (var studenty in sequenceString)
    {
        Console.WriteLine($"{studenty.firstName} {studenty.age}");
    }
    //.OrderBy 
    //.ThenBy
    Console.WriteLine("Liste des chiffres inférieurs à 5");
    foreach (int number in numbers)
    {
        if (number < 5)
        {
            Console.WriteLine(number);
        }
    }
    Console.WriteLine("Liste des chiffres inférieurs à 5 avec LINQ");
    var sequence = numbers.Where(number => number < 5).OrderBy(numbers => numbers);

    foreach (int number in sequence)
    {
        Console.WriteLine(number);
    }


    string[] fruits = { "Pomme", "Poire", "Prune", "Ananas", "Banane" };
    var sequenceFruits = fruits.Where(fruits => fruits.Length > 5);
    Console.WriteLine(string.Join("\n", sequenceFruits));
    foreach (var fruit in sequenceFruits)
    {
        Console.WriteLine(fruit);
    }
}

