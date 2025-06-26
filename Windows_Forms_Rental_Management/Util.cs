using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Windows_Forms_Rental_Management
{
    public static class Util
    {

        public static async Task LoadComboBox<T>(ComboBox cb, string endpoint, string displayMember, string valueMemeber)
        {
            var items = await FetchAllDataFromApiAsync<T>(endpoint);
            if (items != null)
            {
                cb.DataSource = items;
                cb.DisplayMember = displayMember;
                cb.ValueMember = valueMemeber;
            }
        }
        public static async Task<List<T>?> FetchAllDataFromApiAsync<T>(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await LocalClientWithBaseAddress.client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    List<T>? result = JsonSerializer.Deserialize<List<T>>(json, options);
                    return result;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error fetching data from {endpoint}: {ex.Message}");
            }

            return null;
        }

        public static async Task<HttpResponseMessage> DeleteItemAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await LocalClientWithBaseAddress.client.DeleteAsync(endpoint);
                return response;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP error while deleting from {endpoint}:\n{ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    ReasonPhrase = "HttpRequestException: " + ex.Message
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Exception: " + ex.Message
                };
            }
        }

        public static async Task<HttpResponseMessage> AddItemAsync<T>(string endpoint, T item)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await LocalClientWithBaseAddress.client.PostAsync(endpoint, content);
                return response;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP error while adding: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    ReasonPhrase = "HttpRequestException: " + ex.Message
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Exception: " + ex.Message
                };
            }
        }


        public static async Task<HttpResponseMessage> UpdateItemAsync<T>(string endpoint, T item)
        {
            try
            {
                var json = JsonSerializer.Serialize(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await LocalClientWithBaseAddress.client.PutAsync(endpoint, content);
                return response;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP error while updating: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    ReasonPhrase = "HttpRequestException: " + ex.Message
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Exception: " + ex.Message
                };
            }
        }


        public static async Task<T?> FetchSingleItemFromApiAsync<T>(string endpoint)
{
    try
    {
        HttpResponseMessage response = await LocalClientWithBaseAddress.client.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(json, options);
        }
        else
        {
            MessageBox.Show($"Failed to fetch item.\nStatus: {(int)response.StatusCode} - {response.ReasonPhrase}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return default;
        }
    }
    catch (HttpRequestException ex)
    {
        MessageBox.Show($"HTTP error: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return default;
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return default;
    }
}

    }
}
