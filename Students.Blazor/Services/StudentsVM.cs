using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Students_UseCase.Models;
using Students_UseCase.Serviecs;

namespace Students.Blazor.Services

{
    public class StudentsVM : XMLStudentSerializer
    {
        #region properties
        static HttpClient client = new HttpClient();

        #endregion

        #region Helper
        public async Task<HttpStatusCode> CreateStudentAsync(Student student)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                   Session.UrlString + "api/Students", student);
                response.EnsureSuccessStatusCode();

                if (!response.IsSuccessStatusCode)
                {
                    CreateAction(student.Id, (int)ActionType.Add);
                }
                // return URI of the created resource.
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public async Task<ObservableCollection<Student>> GetStudentAsync()
        {
            try
            {
                ObservableCollection<Student> studentList = null;
                HttpResponseMessage response = await client.GetAsync(Session.UrlString + "api/Students");
                if (response.IsSuccessStatusCode)
                {
                    studentList = await response.Content.ReadFromJsonAsync<ObservableCollection<Student>>();
                }
                return studentList;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"{Session.UrlString}api/Students/{student.Id}", student);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
            {
                CreateAction(student.Id, (int)ActionType.Update);


            }
            // Deserialize the updated Student from the response body.
            student = await response.Content.ReadFromJsonAsync<Student>();
            return student;
        }

        public async Task<HttpStatusCode> DeleteStudentAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"{Session.UrlString}api/Students/{id}");
            if (!response.IsSuccessStatusCode)
            {
                CreateAction(id, (int)ActionType.Delete);
            }
            return response.StatusCode;
        }

        #endregion
    }
}

