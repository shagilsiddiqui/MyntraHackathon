import 'dart:developer';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:camera/camera.dart';
import 'package:image_picker/image_picker.dart';

class AddImageScreen extends StatefulWidget {
  @override
  _AddImageScreenState createState() => _AddImageScreenState();
}

class _AddImageScreenState extends State<AddImageScreen> {
  Future<File> file;
  File tmpFile;
  String fileName;
  chooseImage() {
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: Text('Please select the source'),
        actions: <Widget>[
          FlatButton(
            child: Text('Camera'),
            onPressed: () {
              setState(() {
                file = ImagePicker.pickImage(
                    source: ImageSource.camera, maxHeight: 720, maxWidth: 720);
              });
              int count = 1;
              Navigator.popUntil(context, (route) {
                return count++ == 2;
              });
            },
          ),
          FlatButton(
            child: Text('Gallery'),
            onPressed: () {
              setState(() {
                file = ImagePicker.pickImage(
                    source: ImageSource.gallery, maxHeight: 720, maxWidth: 720);
              });
              int count = 1;
              Navigator.popUntil(context, (route) {
                return count++ == 2;
              });
            },
          )
        ],
      ),
    );
  }

  Widget showImage() {
    return FutureBuilder<File>(
      future: file,
      builder: (BuildContext context, AsyncSnapshot<File> snapshot) {
        if (snapshot.connectionState == ConnectionState.done &&
            null != snapshot.data) {
          tmpFile = snapshot.data;
          fileName = tmpFile.path.split('/').last;
          log(fileName);
          return Image.file(tmpFile);
        } else if (null != snapshot.error) {
          return const Text(
            'Error Picking Image',
            textAlign: TextAlign.center,
          );
        } else {
          return const Text(
            'No Image Selected',
            textAlign: TextAlign.center,
          );
        }
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Scan Body"),
      ),
      body: Column(
        children: [
          OutlineButton(
            onPressed: chooseImage,
            child: Text('Add an Image'),
          ),

          Container(child: showImage()),

OutlineButton(
            onPressed: chooseImage,
            child: Text('Cßreate Avatar'),
          ),

        ],
      ),
    );
  }
}
