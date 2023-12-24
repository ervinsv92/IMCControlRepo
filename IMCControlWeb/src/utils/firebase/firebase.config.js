// Import the functions you need from the SDKs you need

import { initializeApp } from "firebase/app";
import { getAuth } from "firebase/auth";

// Your web app's Firebase configuration
const firebaseConfig = {
    apiKey: "AIzaSyBKwmHCl2leFwIEcAswMxA4pQJNZkMmrjA",
    authDomain: "imccontrol-44530.firebaseapp.com",
    projectId: "imccontrol-44530",
    storageBucket: "imccontrol-44530.appspot.com",
    messagingSenderId: "434998114777",
    appId: "1:434998114777:web:926e6ef825d956d120c1c8"
};
  
const fireApp = initializeApp(firebaseConfig);
const fireAuth = getAuth(fireApp);

export {
  fireApp,
  fireAuth
}