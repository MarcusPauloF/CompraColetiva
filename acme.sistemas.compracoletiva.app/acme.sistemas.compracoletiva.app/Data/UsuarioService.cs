using Java.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Android.Graphics.ColorSpace;

namespace acme.sistemas.compracoletiva.app.Data
{
    public class UsuarioService
    {
        public async Task<string> Login(string login, string senha)
        {
            Logar logar = new Logar()
            {
                email = login,
                senha = senha
            };
            string url = "https://compracoletiva.acmesistemas.com.br/api/usuario/login";
            var stringContent = new StringContent(JsonConvert.SerializeObject(logar), Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            IEnumerable<string> valor = new string[] { "MIIEpAIBAAKCAQEAzOEnR0LSdal9Yp6tJBV9P7DwCvZIQbWoJ2rL5lLqGl4cjfeH7SDO5KP3DKSkEs4W0Q9IIFk7VTCGn9nveh3ZrYptMyQ /UW2lath6ur9svHKivMT7s83/lVoaSh1e5LqfXvClaYh4jMFP3aZ9Tu7gWnYrdEZG7VwRBQqkZeisZ3MkT+JhokNSu9i9C7XFjoL/ecPkZ1F1a1QZdOpvy7BFv98v5SUatnZkFyGSNR/7nbIHP6VZysq3/X0ScROZH4bYcawyH17Sv6lbK2SjVeyyhbYuSrvr8MYSqYtmWmjvTV43shJUm5+WYXDG0URZvQDpuuop4DZVBOArJe8m5aRTNQIDAQABAoIBAQCxib52wxILQhdUWXpiFXkWsyYf6bFNt7QCjEoqydjxhnIqF8EjHFYMzYUs4JMJdKtS+HIhDhIbTVSrurgJ00opVxYvxg5UarZ4cyVPJMh+OLyK5gvTkQQUkSLM7MypWor2Q4Sjgc4s8utZgId/2gJygYpAVRHrZ+ebvdAeO1UCwrgoAxXQGaej/ZK46OPb1qgSo7cdzejY88RbP7Hysp9p8TyRKKNspFM58zb+qhTw5d6Cu60+Fde4aKSby3EA5fHXmGOv+wBiC9crAasFIfxwF3x3qo1xPGmViWOO25H1iWXvOSsvYa/dyny/PnwoQUOXqFRXdBELsVzV2ebc11g1AoGBAOyw2RWctPPJJKG8S4hfOJfvWljuClpNij9H2O2mHGvIct0rCAYSQx0SYk//s9oyGmR3FHZXAtmD3tG0NH3oc1LWwMQOPCcOHOC2N36OAu1UM69djznZREwEDB+VlyP+DwgQL0HYW+Nzj5hbhRtM1dNEhv86tLzQQbaKCytbU9CfAoGBAN2X8cx/FnBN9SVYyKskxrcbElfnFQNGhI7Aj9wjS0arIqxSRsik1R/fN9GedjdXcrFmPxdBqJqnnRpzkO8HURqAwEaiy8S9CbrbMS64rnIVYt3q8Eu2bbVPU7eyLxHK5+gffsPNap9PLrU9ExF+E80mDhQDmEQtcyWovSUhSGerAoGBAObvGa+riSY+/73KIQw6k9YyE72m63T2KMfbSv18UEidd+zw2lBKKy9HS6LwQsPGlNenE9Duznn530JOB9U9IqAVpljj5q7YZzacswKIfrSerhsRNvhjUu60GDwM0T2t2W6tk94zwlvm2Zj22qUrT4llWC3YUpXSv/rhL0qrPdjTAoGAHtfhXhdqZiNTtekPtVKfHil0eiu97wDHvp7q5zc6aRG098tT8uWOjKsjN9gYmEdhvXN/4JrQ/wXJhj8Ds2GPVmMJYEuUlUPCsPGFfP1TuqljY4QqAj/YMV5jRrRUfOODN/n6SQK0jowU8kEYAF1OIEXlu79sWEEDQACmox5o15UCgYBWw9BgaUHI/9incNxL7YSLfbRaOoTNATmxa8CK+MAU0IslgN97qfH7UxQH9OwmG6n3o4YB7n06hHYiBToUUFUy+bX0Pl0Qty/aiItReAaiMRwU2Inisgn8mvS6Xp2+oawXz9ODmHiYYT5tuvn/R7J1Q4xOwI4fwQc1mnXYwjca7A==" };
            client.DefaultRequestHeaders.Add("privateKey", "MIIEpAIBAAKCAQEAzOEnR0LSdal9Yp6tJBV9P7DwCvZIQbWoJ2rL5lLqGl4cjfeH7SDO5KP3DKSkEs4W0Q9IIFk7VTCGn9nveh3ZrYptMyQ/UW2lath6ur9svHKivMT7s83/lVoaSh1e5LqfXvClaYh4jMFP3aZ9Tu7gWnYrdEZG7VwRBQqkZeisZ3MkT+JhokNSu9i9C7XFjoL/ecPkZ1F1a1QZdOpvy7BFv98v5SUatnZkFyGSNR/7nbIHP6VZysq3/X0ScROZH4bYcawyH17Sv6lbK2SjVeyyhbYuSrvr8MYSqYtmWmjvTV43shJUm5+WYXDG0URZvQDpuuop4DZVBOArJe8m5aRTNQIDAQABAoIBAQCxib52wxILQhdUWXpiFXkWsyYf6bFNt7QCjEoqydjxhnIqF8EjHFYMzYUs4JMJdKtS+HIhDhIbTVSrurgJ00opVxYvxg5UarZ4cyVPJMh+OLyK5gvTkQQUkSLM7MypWor2Q4Sjgc4s8utZgId/2gJygYpAVRHrZ+ebvdAeO1UCwrgoAxXQGaej/ZK46OPb1qgSo7cdzejY88RbP7Hysp9p8TyRKKNspFM58zb+qhTw5d6Cu60+Fde4aKSby3EA5fHXmGOv+wBiC9crAasFIfxwF3x3qo1xPGmViWOO25H1iWXvOSsvYa/dyny/PnwoQUOXqFRXdBELsVzV2ebc11g1AoGBAOyw2RWctPPJJKG8S4hfOJfvWljuClpNij9H2O2mHGvIct0rCAYSQx0SYk//s9oyGmR3FHZXAtmD3tG0NH3oc1LWwMQOPCcOHOC2N36OAu1UM69djznZREwEDB+VlyP+DwgQL0HYW+Nzj5hbhRtM1dNEhv86tLzQQbaKCytbU9CfAoGBAN2X8cx/FnBN9SVYyKskxrcbElfnFQNGhI7Aj9wjS0arIqxSRsik1R/fN9GedjdXcrFmPxdBqJqnnRpzkO8HURqAwEaiy8S9CbrbMS64rnIVYt3q8Eu2bbVPU7eyLxHK5+gffsPNap9PLrU9ExF+E80mDhQDmEQtcyWovSUhSGerAoGBAObvGa+riSY+/73KIQw6k9YyE72m63T2KMfbSv18UEidd+zw2lBKKy9HS6LwQsPGlNenE9Duznn530JOB9U9IqAVpljj5q7YZzacswKIfrSerhsRNvhjUu60GDwM0T2t2W6tk94zwlvm2Zj22qUrT4llWC3YUpXSv/rhL0qrPdjTAoGAHtfhXhdqZiNTtekPtVKfHil0eiu97wDHvp7q5zc6aRG098tT8uWOjKsjN9gYmEdhvXN/4JrQ/wXJhj8Ds2GPVmMJYEuUlUPCsPGFfP1TuqljY4QqAj/YMV5jRrRUfOODN/n6SQK0jowU8kEYAF1OIEXlu79sWEEDQACmox5o15UCgYBWw9BgaUHI/9incNxL7YSLfbRaOoTNATmxa8CK+MAU0IslgN97qfH7UxQH9OwmG6n3o4YB7n06hHYiBToUUFUy+bX0Pl0Qty/aiItReAaiMRwU2Inisgn8mvS6Xp2+oawXz9ODmHiYYT5tuvn/R7J1Q4xOwI4fwQc1mnXYwjca7A==");

            var res = await client.PostAsync(url, stringContent);
            var result = await res.Content.ReadAsStringAsync();

            return result;
        }
    }
    public class Logar
    {
        public string email { get; set; }
        public string senha { get; set; }
    }
}
