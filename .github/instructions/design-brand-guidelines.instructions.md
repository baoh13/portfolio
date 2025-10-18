---
applyTo: '*.css'
---

# Design and Brand Guidelines

## Typography
- **Primary Font**: Montserrat (sans-serif)
- **Secondary Font**: Cormorant Garamond (serif)
- **Font Weights**: Use weights 200, 300, 400, 600, and 800 as appropriate.
- **Headings**:
  - h1: Font size ranges from 3rem to 7rem depending on screen size.
  - h2: Font size 2rem, centered.
  - h3: Font size 1.25rem.
- **Paragraphs**:
  - Default font size: 18px.
  - Line height: 1.5.
  - Variants: .large (24px), .small (15px).

## Color Palette
- **Primary Gradient**: Linear gradient from rgb(5, 39, 103) to #3a0647 (dark purple).
- **Light Background**: rgba(255, 255, 255, 0.35) (semi-transparent white).
- **Dark Background**: rgba(0, 0, 0, 0.25) (semi-transparent black).
- **Text Colors**:
  - Light sections: Black.
  - Dark sections: White.
- **Links**:
  - Default: Black.
  - Hover: #4e567e (muted purple).

## Layout
- **Page Structure**:
  - .page: Flex container, column layout by default.
  - main: Flexible content area.
- **Sidebar**:
  - Width: 250px (on screens wider than 641px).
  - Sticky positioning.
- **Top Row**:
  - Height: 3.5rem.
  - Background: #f7f7f7 (light gray).
  - Border: 1px solid #d6d5d5 (gray).

## Components
- **Footer**:
  - ID: #contact.
  - Centered content with a gap of 2.5rem.
  - Padding: 5rem 0 3rem.
- **Portfolio Section**:
  - .portfolio-container: Flex layout, row direction.
  - .portfolio-hero: Max width 40%.

## Responsive Design
- **Breakpoints**:
  - Small screens (max-width: 640.98px): Adjust .top-row alignment.
  - Medium screens (max-width: 420px): Adjust .portfolio-container to column layout.
- **Typography Adjustments**:
  - h1 font size scales for screens under 420px.

## Animations
- **Loading Progress**:
  - Circular progress indicator with smooth transitions.

## Best Practices
- Use semantic HTML elements for better accessibility.
- Maintain consistent spacing and alignment across components.
- Test designs on multiple screen sizes to ensure responsiveness.