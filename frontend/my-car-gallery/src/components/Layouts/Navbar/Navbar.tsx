import "./Navbar.scss";
import { Link } from "react-router-dom";
import LanguageSwitcher from "../LanguageSwitcher/LanguageSwitcher";

const Navbar = () => {
  return (
    <nav className="navbar">
      <div className="logo">
        <Link to="/">
          <img src="/assets/images/icon/autovibe-icon.svg" alt="AutoVibe Logo" />
          <span className="brand-name">Auto<span className="highlight">Vibe</span></span>
        </Link>
      </div>

      <ul className="nav-links">
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/about">About</Link>
        </li>
        <li>
          <Link to="/gallery">Gallery</Link>
        </li>
        <li>
          <Link to="/contact">Contact</Link>
        </li>
      </ul>


    <div className="right-section">
        <LanguageSwitcher/>
      <div className="auth">
        <Link to="/login" className="sign-in-btn">Sign In</Link>
      </div>

    </div>
    </nav>
  );
};

export default Navbar;
