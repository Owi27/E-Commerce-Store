import Header from "./Header";
import Footer from "./Footer";
import Products from "./Products";
import Login from "./Login";
import Verify from "./Verify";
import ResetPassword from "./ResetPassword";
import User from "./User";
import About from "./About";
import Error from "./Error";
import Success from "./Success";
import Failed from "./Failed";
import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  
  return(
    <>
        <BrowserRouter>
        <Header/>
        <Routes>
          <Route path="/" element={<Products/>}/>
          <Route path="/Login" element={<Login/>}/>
          <Route path="/User" element={<User/>}/>
          <Route path="/Verify/:token" element={<Verify/>}/>
          <Route path="/ResetPassword/:token" element={<ResetPassword/>}/>
          <Route path="/About" element={<About/>}/>
          <Route path="/Success" element={<Success/>}/>
          <Route path="/Failed" element={<Failed/>}/>
          <Route path="*" element={<Error/>}/>
        </Routes>
        </BrowserRouter>
      <Footer/>
    </>
  );
}

export default App;