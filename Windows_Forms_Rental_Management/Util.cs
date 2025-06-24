using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
