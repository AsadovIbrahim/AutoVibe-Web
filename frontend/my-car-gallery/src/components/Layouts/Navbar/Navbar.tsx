import "./Navbar.scss";
import { Link } from "react-router-dom";
import LanguageSwitcher from "../LanguageSwitcher/LanguageSwitcher";
import { useAppSelector, useAppDispatch } from "../../../hooks/useAppDispatch";
import { useState } from "react";
import { Logout } from "../../../services/authentication/authSlice";
import Swal from "sweetalert2";

const Navbar = () => {
  const dispatch = useAppDispatch();
  const profilePhoto = useAppSelector((state) => state.auth.profilePhoto);
  const isAuthenticated = useAppSelector((state) => state.auth.isAuthenticated);
  const [isDropdownOpen, setDropdownOpen] = useState(false);

  const handleLogout = () => {
    Swal.fire({
      title: "Are you sure you want to log out?",
      text: "If you log out, you will need to log in again to access your account.",
      icon: "warning",  
      showCancelButton: true,  
      confirmButtonColor: "#3085d6",  
      cancelButtonColor: "#d33", 
      confirmButtonText: "Yes, log me out",
      cancelButtonText: "Cancel",
    }).then((result) => {
      if (result.isConfirmed) {
        dispatch(Logout()); 
      }
    });
  };

  return (
    <nav className="navbar">
      <div className="logo">
        <Link to="/">
          <img src="/assets/images/icon/autovibe-icon.svg" alt="AutoVibe Logo" />
          <span className="brand-name">Auto<span className="highlight">Vibe</span></span>
        </Link>
      </div>

      <ul className="nav-links">
        <li><Link to="/">Home</Link></li>
        <li><Link to="/about">About</Link></li>
        <li><Link to="/gallery">Gallery</Link></li>
        <li><Link to="/contact">Contact</Link></li>
      </ul>

      <div className="right-section">
        <LanguageSwitcher />
        {!isAuthenticated ? (
          <div className="auth">
            <Link to="/login" className="sign-in-btn">Sign In</Link>
          </div>
        ) : (
          <div className="profile-section">
            <img
              src={profilePhoto || "/assets/images/icon/autovibe-icon.svg"}
              alt="Profile"
              className="profile-photo"
              onClick={() => setDropdownOpen(!isDropdownOpen)}
            />
            {isDropdownOpen && (
              <div className="profile-dropdown">
                <Link to="/profile" onClick={() => setDropdownOpen(false)}>Profile Settings</Link>
                <button onClick={handleLogout}>Log Out</button>
              </div>
            )}
          </div>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
