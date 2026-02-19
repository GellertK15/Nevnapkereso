import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { BrowserRouter,Routes,Route } from 'react-router-dom';
import Menu from './layout/menu.jsx';
import Header from './layout/header.jsx';
import Footer from './layout/footer.jsx';
import Nevnap from './pages/Nevnap.jsx';
import Szulinap from './pages/Szulinap.jsx';
import Contact from './pages/Contact.jsx';



createRoot(document.getElementById('root')).render(
  <StrictMode>
    <BrowserRouter>
      <Header />
      <Menu />
      <Routes>
        <Route path="/" element={<App />} />
        <Route path="/nevnap" element={<Nevnap />} />
        <Route path="/szulinap" element={<Szulinap />} />
        <Route path="/kapcsolat" element={<Contact />} />
      </Routes>
      <Footer />
    </BrowserRouter>
  </StrictMode>,
)
