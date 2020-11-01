import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_webview_plugin/flutter_webview_plugin.dart';

class web extends StatelessWidget {
  String selectedUrl="https://api.cappasity.com/api/player/8d1a1a9f-9677-4f16-b41e-79be2e04a704/embedded?autorun=0&closebutton=0&logo=0&analytics=1&uipadx=0&uipady=0&enablestoreurl=0&storeurl=&hidehints=0&autorotate=0&autorotatetime=10&autorotatedelay=2&autorotatedir=1&hidefullscreen=1&hideautorotateopt=1&hidesettingsbtn=1&enableimagezoom=1&zoomquality=1&hidezoomopt=0&arbutton=1";
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return  new MaterialApp(
      title: 'Flutter WebView Demo',
      theme: new ThemeData(
        primarySwatch: Colors.blue,
      ),
      routes: {
        '/': (_) =>  Scaffold(
          appBar:AppBar(
            leading:  IconButton(
              icon: Icon(
                Icons.arrow_back,
              ),
              onPressed: () {
                Navigator.pop(context);
              },
            )
          ),
          body: SafeArea(
            child: WebviewScaffold(
              url: selectedUrl,
              withZoom: true,
              withLocalStorage: true,
              hidden: true,
              initialChild: Container(
                color: Colors.white,
                child: const Center(
                  child: Text('Waiting.....'),
                ),
              ),
            ),
          ),
        ),
      },
    );
  }
}

