# FetchMyIP
FetchMyIP is a simple API for retrieving the IP address of the requester. It supports multiple formats including Plain Text, JSON, XML, JSONP, and custom JSONP callbacks.

## API Endpoints
- Plain Text: <br>
https://get.fetchmyip.io
- JSON Format: <br>
https://get.fetchmyip.io?format=json
- XML Format: <br>
https://get.fetchmyip.io?format=xml
- JSONP Format: <br>
https://get.fetchmyip.io?format=jsonp
- JSONP with Custom Callback: <br>
https://get.fetchmyip.io?format=jsonp&callback=yourCallback

# Usage Examples

## Bash
```bash
#!/bin/bash

ip=$(curl -s https://get.fetchmyip.io)
echo "My public IP address is: $ip"
```
## NGS (Next Generation Shell)
```ngs
ip=`curl -s https://get.fetchmyip.io`
echo("My public IP address is: $ip")
```

## Python
```python
# This example requires the requests library be installed.  You can learn more
# about the Requests library here: http://docs.python-requests.org/en/latest/
from requests import get

ip = get('https://get.fetchmyip.io').text
print('My public IP address is: {}'.format(ip))
```
## Ruby
```ruby
require "net/http"

ip = Net::HTTP.get(URI("https://get.fetchmyip.io"))
puts "My public IP Address is: " + ip
```

## PHP
```php
<?php
    $ip = file_get_contents('https://get.fetchmyip.io');
    echo "My public IP address is: " . $ip;
?>
```

# Java
```java
try (java.util.Scanner s = new java.util.Scanner(new java.net.URL("https://get.fetchmyip.io").openStream(), "UTF-8").useDelimiter("\\A")) {
    System.out.println("My current IP address is " + s.next());
} catch (java.io.IOException e) {
    e.printStackTrace();
}
```

# Perl
```perl
use strict;
use warnings;
use LWP::UserAgent;

my $ua = new LWP::UserAgent();
my $ip = $ua->get('https://get.fetchmyip.io')->content;
print 'My public IP address is: '. $ip;
```

# C#
```cs
var httpClient = new HttpClient();
var ip = await httpClient.GetStringAsync("https://get.fetchmyip.io");
Console.WriteLine($"My public IP address is: {ip}");
```

# VB.NET
```vb
Dim httpClient As New System.Net.Http.HttpClient
Dim ip As String = Await httpClient.GetStringAsync("https://get.fetchmyip.io")
Console.WriteLine($"My public IP address is: {ip}")
```

# NodeJS
```js
var http = require('http');

http.get({'host': 'get.fetchmyip.io', 'port': 80, 'path': '/'}, function(resp) {
  resp.on('data', function(ip) {
    console.log("My public IP address is: " + ip);
  });
});
```

# GO
```go
package main

import (
        "io/ioutil"
        "net/http"
        "os"
)

func main() {
        res, _ := http.Get("https://get.fetchmyip.io")
        ip, _ := ioutil.ReadAll(res.Body)
        os.Stdout.Write(ip)
}
```

# Racket
```
(require net/url)

(define ip (port->string (get-pure-port (string->url "https://get.fetchmyip.io"))))
(printf "My public IP address is: ~a" ip)
```

# Lisp
```lisp
;This example requires the drakma http package installed.
;It can be found here: http://www.weitz.de/drakma

(let ((stream
    (drakma:http-request "https://get.fetchmyip.io" :want-stream t)))
  (let ((public-ip (read-line stream)))
    (format t "My public IP address is: ~A" public-ip)))
```

# Xojo
```xojo
Dim s As New HTTPSecureSocket
Dim t As String = s.Get("https://get.fetchmyip.io",10)
MsgBox "My public IP Address is: " + t
```

# Scala
```scala
val addr = scala.io.Source.fromURL("https://get.fetchmyip.io").mkString
println(s"My public IP address is: $addr")
```

# Javascript
```js
<script type="application/javascript">
  function getIP(json) {
    document.write("My public IP address is: ", json.ip);
  }
</script>

<script type="application/javascript" src="https://get.fetchmyip.io?format=jsonp&callback=getIP"></script>
```

# jQuery
```js
<script type="application/javascript">
  $(function() {
    $.getJSON("https://get.fetchmyip.io?format=jsonp&callback=?",
      function(json) {
        document.write("My public IP address is: ", json.ip);
      }
    );
  });
</script>
```

# Elixir
```elixir
:inets.start
{:ok, {_, _, inet_addr}} = :httpc.request('http://get.fetchmyip.io')
:inets.stop
```

# Nim
```nim
import HttpClient
var ip = newHttpClient().getContent("https://get.fetchmyip.io")
echo("My public IP address is: ", ip)
```

# PowerShell
```ps
$ip = Invoke-RestMethod -Uri 'https://get.fetchmyip.io?format=json'
"My public IP address is: $($ip.ip)"
```

# Lua
```lua
socket_http = require "http.compat.socket"
body = assert(socket_http.request("https://get.fetchmyip.io"))
print(body)
```

# PureBasic
```basic
InitNetwork()
*Buffer = ReceiveHTTPMemory("https://get.fetchmyip.io?format=json")
If *Buffer
  ParseJSON(0, PeekS(*Buffer, MemorySize(*Buffer), #PB_UTF8))
  FreeMemory(*Buffer)
  Debug GetJSONString(GetJSONMember(JSONValue(0), "ip"))
EndIf
```

# LiveCode
```livecode
put "My public IP address is" && url "https://get.fetchmyip.io"
```

# Objective-C
```objc
NSURL *url = [NSURL URLWithString:@"https://get.fetchmyip.io/"];
NSString *ipAddress = [NSString stringWithContentsOfURL:url encoding:NSUTF8StringEncoding error:nil];
NSLog(@"My public IP address is: %@", ipAddress);
```

# Swift
```swift
import Foundation

let url = URL(string: "https://get.fetchmyip.io")

do {
    if let url = url {
        let ipAddress = try String(contentsOf: url)
        print("My public IP address is: " + ipAddress)
    }
} catch let error {
    print(error)
}
```

# Ardunio
```c
if (client.connect("get.fetchmyip.io", 80)) {
    Serial.println("connected");
    client.println("GET / HTTP/1.0");
    client.println("Host: get.fetchmyip.io");
    client.println();
} else {
    Serial.println("connection failed");
}
```

# AutoIT
```autoit
$b = TimerInit()
$Read = InetRead("https://get.fetchmyip.io",1)
$sData = BinaryToString($Read)
MsgBox(64,"Information","Your IP Address: " & $sData & @CRLF & "Elapsed Time: " & StringLeft(TimerDiff($b) / 1000,4) & " seconds.")
```
