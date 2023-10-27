import Header from "./Header";
import Footer from "./Footer";
import Products from "./Products";
import Login from "./Login";
import About from "./About";
import Error from "./Error";
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
          <Route path="/About" element={<About/>}/>
          <Route path="*" element={<Error/>}/>
        </Routes>
        </BrowserRouter>
      <Footer/>
    </>
  );
}

export default App;