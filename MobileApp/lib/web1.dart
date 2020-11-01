import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_webview_plugin/flutter_webview_plugin.dart';

class web1 extends StatelessWidget {
  String selectedUrl="https://sketchfab.com/models/8202cb5fdf654563aa6e3d8e188a17d1/embed?autostart=0&amp;ui_controls=1&amp;ui_infos=1&amp;ui_inspector=1&amp;ui_stop=1&amp;ui_watermark=1&amp;ui_watermark_link=1%22%20frameborder=%220%22%20allow=%22autoplay;%20fullscreen;%20vr%22%20mozallowfullscreen=%22true%22%20webkitallowfullscreen=%22true%22";
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

