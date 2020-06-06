import React from 'react';
import ReactDOM from 'react-dom';
import WebFont from 'webfontloader';
import "./web.config";

import App from './App';

import 'styles/index.scss';

WebFont.load({
  google: {
    families: ['Roboto:300,400,500,700', 'sans-serif']
  }
});

ReactDOM.render(<App />, document.getElementById('root'));
