using System;

namespace API_Dell.Validations
{
  public class Validations
  {
    public static bool isLegalAge(DateTime birthDate)
    {
      DateTime today = DateTime.Today;
      int age = today.Year - birthDate.Year;
      if (birthDate > today.AddYears(-age)) age--;
      return age >= 18;
    }
    public static bool IsCpf(string cpf)
    {
      int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      string tempCpf;
      string digit;
      int sum;
      int rest;
      cpf = cpf.Trim();
      cpf = cpf.Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
        return false;
      tempCpf = cpf.Substring(0, 9);
      sum = 0;

      for (int i = 0; i < 9; i++)
        sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
      rest = sum % 11;
      if (rest < 2)
        rest = 0;
      else
        rest = 11 - rest;
      digit = rest.ToString();
      tempCpf = tempCpf + digit;
      sum = 0;
      for (int i = 0; i < 10; i++)
        sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
      rest = sum % 11;
      if (rest < 2)
        rest = 0;
      else
        rest = 11 - rest;
      digit = digit + rest.ToString();
      return cpf.EndsWith(digit);
    }
  }
}