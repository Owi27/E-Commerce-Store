import Header from "./Header";
import Footer from "./Footer";
import Products from "./Products";
import "./App.css";

function App() {
  
  return(
    <>
      <Header/>
        <div className="container">
          <Products/>
        </div>
      <Footer/>
    </>
  );
}

export default App;