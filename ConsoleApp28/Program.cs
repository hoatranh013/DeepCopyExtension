using MediatR;
using System;
using System.Numerics;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;

public class BasicProperties
{
    public string Name { get; set; }
    public string TypeName { get; set; }
}
public interface Basic
{

}
public class Person : Basic
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public Profile profile { get; set; }
    public Related related { get; set; }
    public Person ()
    {

    }
    public Person (string name, string address, int age, Profile profile, Related related)
    {
        Name = name;
        Address = address;
        Age = age;
        this.profile = profile;
        this.related = related;
    }
    public override string ToString()
    {
        StringBuilder GETSTRING = new StringBuilder();
        var getAllClasses = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => !x.IsInterface && typeof(Basic).IsAssignableFrom(x)).Select(x => x.Name);
        var getVariables = this.GetType().GetProperties()
        .Where(x => !getAllClasses.Contains(x.PropertyType.Name))
        .Select(x => new BasicProperties
        {
            Name = x.Name,
            TypeName = x.PropertyType.Name
        }).ToList();
        var getAllProperties = this.GetType().GetProperties().Select(x => x.Name).ToList();
        foreach (var property in getAllProperties)
        {
            if (getVariables.Select(x => x.Name).Contains(property))
            {
                var value = this.GetType()?.GetProperty(property)?.GetValue(this)?.ToString();
                GETSTRING.Append(property);
                GETSTRING.Append("_");
                GETSTRING.Append(value);
                GETSTRING.Append("\n");
            }    
            else
            {
                var value = this.GetType().GetProperty(property).GetValue(this);
                GETSTRING.Append(value.ToString());
            }
        }
        return GETSTRING.ToString();

    }
}

public class Related : Basic
{
    public string PersonOne { get; set; }
    public string PersonTwo { get; set; }

    public string PersonThr { get; set; }
    public Related()
    {

    }
    public Related(string PersonOne, string PersonTwo, string PersonThr)
    {
        this.PersonOne = PersonOne;
        this.PersonTwo = PersonTwo;
        this.PersonThr = PersonThr;
    }
    public override string ToString()
    {
        StringBuilder GETSTRING = new StringBuilder();
        var getAllClasses = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => !x.IsInterface && typeof(Basic).IsAssignableFrom(x)).Select(x => x.Name);
        var getVariables = this.GetType().GetProperties()
        .Where(x => !getAllClasses.Contains(x.PropertyType.Name))
        .Select(x => new BasicProperties
        {
            Name = x.Name,
            TypeName = x.PropertyType.Name
        }).ToList();
        var getAllProperties = this.GetType().GetProperties().Select(x => x.Name).ToList();
        foreach (var property in getAllProperties)
        {
            if (getVariables.Select(x => x.Name).Contains(property))
            {
                var value = this.GetType().GetProperty(property).GetValue(this).ToString();
                GETSTRING.Append(property);
                GETSTRING.Append("_");
                GETSTRING.Append(value);
                GETSTRING.Append("\n");
            }
            else
            {
                var value = this.GetType().GetProperty(property).GetValue(this);
                GETSTRING.Append(value.ToString());
            }
        }
        return GETSTRING.ToString();

    }
}

public class BonusProfile : Basic
{
    public string Weapon { get; set; }
    public string Salary { get; set; }
    public BonusProfile()
    {

    }
    public BonusProfile(string weapon, string salary)
    {
        Weapon = weapon;
        Salary = salary;
    }
    public override string ToString()
    {
        StringBuilder GETSTRING = new StringBuilder();
        var getAllClasses = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => !x.IsInterface && typeof(Basic).IsAssignableFrom(x)).Select(x => x.Name);
        var getVariables = this.GetType().GetProperties()
        .Where(x => !getAllClasses.Contains(x.PropertyType.Name))
        .Select(x => new BasicProperties
        {
            Name = x.Name,
            TypeName = x.PropertyType.Name
        }).ToList();
        var getAllProperties = this.GetType().GetProperties().Select(x => x.Name).ToList();
        foreach (var property in getAllProperties)
        {
            if (getVariables.Select(x => x.Name).Contains(property))
            {
                var value = this.GetType().GetProperty(property).GetValue(this).ToString();
                GETSTRING.Append(property);
                GETSTRING.Append("_");
                GETSTRING.Append(value);
                GETSTRING.Append("\n");
            }
            else
            {
                var value = this.GetType().GetProperty(property).GetValue(this);
                GETSTRING.Append(value.ToString());
            }
        }
        return GETSTRING.ToString();

    }
}

public class Profile : Basic
{
    public string Document { get; set; }
    public string Reference { get; set; }
    public int Value { get; set; }

    public BonusProfile bonusProfile { get; set; }

    public Profile()
    { 

    }
    public Profile(string document, string reference, int value, BonusProfile bonusProfile)
    {
        Document = document;
        Reference = reference;
        Value = value;
        this.bonusProfile = bonusProfile;
    }
    public override string ToString()
    {
        StringBuilder GETSTRING = new StringBuilder();
        var getAllClasses = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => !x.IsInterface && typeof(Basic).IsAssignableFrom(x)).Select(x => x.Name);
        var getVariables = this.GetType().GetProperties()
        .Where(x => !getAllClasses.Contains(x.PropertyType.Name))
        .Select(x => new BasicProperties
        {
            Name = x.Name,
            TypeName = x.PropertyType.Name
        }).ToList();
        var getAllProperties = this.GetType().GetProperties().Select(x => x.Name).ToList();
        foreach (var property in getAllProperties)
        {
            if (getVariables.Select(x => x.Name).Contains(property))
            {
                var value = this.GetType().GetProperty(property).GetValue(this).ToString();
                GETSTRING.Append(property);
                GETSTRING.Append("_");
                GETSTRING.Append(value);
                GETSTRING.Append("\n");
            }
            else
            {
                var value = this.GetType().GetProperty(property).GetValue(this);
                GETSTRING.Append(value.ToString());
            }
        }
        return GETSTRING.ToString();

    }
}

public class CloneFactory<T> where T : Basic, new()
{
    private T getObject;
    public CloneFactory(T getObject)
    {
        this.getObject = getObject;
    }
    public T CloneObject(params string[] paramLists)
    {
        var clone = new T();
        var getAllClasses = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => !x.IsInterface && typeof(Basic).IsAssignableFrom(x)).Select(x => x.Name);
        var getVariables = clone.GetType().GetProperties()
        .Where(x => !getAllClasses.Contains(x.PropertyType.Name))
        .Select(x => new BasicProperties
        {
            Name = x.Name,
            TypeName = x.PropertyType.Name
        }).ToList();
        foreach (var param in paramLists)
        {
            var paramValue = getObject.GetType().GetProperty(param)?.GetValue(getObject);
            if (getVariables.Select(x => x.Name).Contains(param))
            {
                clone.GetType().GetProperty(param)?.SetValue(clone, paramValue);
            }
            else
            {
                var type = paramValue?.GetType();
                var generics = typeof(CloneFactory<>);
                var getGenericType = generics.MakeGenericType(type);
                var getConstructor = getGenericType.GetConstructor(new[] { paramValue.GetType() });
                dynamic? invokeConstructor = getConstructor?.Invoke(new object[] { paramValue });

                var getObjectVariable = paramValue.GetType().GetProperties().Select(x => x.Name).ToList();
                var newCopyObject = invokeConstructor?.CloneObject(getObjectVariable.ToArray());

                clone.GetType().GetProperty(param)?.SetValue(clone, newCopyObject);
            }
        }
        return clone;
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        var person = new Person("Name", "Address", 12, new Profile("Document", "Reference", 12, new BonusProfile("Weapon1", "Salary1")), new Related("one","two","three"));
        var cloing = person;
        var factory = new CloneFactory<Person>(person);
        var cloneone = factory.CloneObject("Name", "profile", "related");
        var clonetwo = factory.CloneObject("Name", "Address", "profile", "related");
        clonetwo.Age = 50;
        cloneone.related.PersonOne = "CLONETWO_ONE";
        cloneone.related.PersonTwo = "CLONETWO_TWO";
        cloneone.related.PersonThr = "CloneTWO_THR";
        cloneone.profile.bonusProfile.Weapon = "CLONEONE_WEAPON1";
        var clontthr = factory.CloneObject("Name", "Age", "profile", "related");
        clontthr.Age = 76;
        clonetwo.profile.Document = "Document2";
        clonetwo.profile.Value = 2;
        var clonefou = factory.CloneObject("Address", "Age", "profile", "related");
        clonefou.Age = 25;
        var clonefiv = factory.CloneObject("Age", "profile", "related");
        clonefiv.profile.Document = "Document5";
        clonefiv.profile.Value = 5;
        clonefou.related.PersonOne = "Clonefour_one";
        clonefou.profile.Document = "Document4";
        clonefou.profile.Value = 4;
        Console.WriteLine(cloneone.ToString());
        Console.WriteLine(clonetwo.ToString());
        Console.WriteLine(clontthr.ToString());
        Console.WriteLine(clonefou.ToString());
        Console.WriteLine(clonefiv.ToString());
        Console.WriteLine(person.ToString());



    }
}