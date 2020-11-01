import 'package:flutter/material.dart';
class measurnment extends StatefulWidget {
  @override
  _measurnmentState createState() => _measurnmentState();
}

class _measurnmentState extends State<measurnment> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Card(
              child: InkWell(
                splashColor: Colors.blue.withAlpha(30),
                onTap: () {
                  print('Card tapped.');
                },
                child: Container(
                  width: 300,
                  height: 100,
                  child: Text('Height:172cm \n chest:41.3(in) \n Across Shoulder:17.8(in) \n Front Length:28.5(in)'),
                ),
              ),
            ),
            SizedBox(
              height: 20,
            ),
            OutlineButton(
              onPressed: (){},
              child: Text('Create Avatar'),
            ),
          ],
        ),

      ),
    );
  }
}
