# Phase 1 Context: Design System Foundation

## Source
User request: Complete UI redesign with dark theme, glassmorphism, Material Design 3 inspiration, custom colors, meaningful icons, information architecture principles.

## Decisions

### D-01: Dark Theme with Glassmorphism [LOCKED]
- Dark background as the base theme for the entire application
- Glassmorphism (glass effect) for container backgrounds — frosted glass appearance with backdrop-filter blur
- Semi-transparent layers with subtle borders to create depth

### D-02: Material Design 3 as Structural Foundation [LOCKED]
- Use Material Design 3 (https://m3.material.io/) for component shapes, layout grid, and structural principles
- NOT using default Material colors — custom color palette required
- M3 shape scale for border radius consistency
- M3 elevation system adapted for dark theme

### D-03: Custom Color Palette [LOCKED]
- Own color identity, not default Material blue/purple
- Colors must work on dark backgrounds with proper contrast
- Need primary, secondary, accent, surface, and error colors
- Glassmorphism-compatible (colors visible through frosted glass)

### D-04: Meaningful Iconography [LOCKED]
- Icons must convey the action or intent they represent
- Shuffle/random icon for seed randomization
- Download/export icon for file export
- Region/location icon for region selector
- Error/warning icon for error controls
- Consistent icon style throughout

### D-05: Information Architecture Principles [LOCKED]
- Organize information for optimal scanning and comprehension
- Clear visual hierarchy — primary actions prominent, secondary actions accessible
- Group related controls logically
- Progressive disclosure — show what's needed, hide complexity
- F-pattern or Z-pattern reading flow consideration

### D-06: Modern Styling with Border Radius [LOCKED]
- Consistent border radius across all components
- Rounded corners for cards, buttons, inputs, containers
- M3 shape scale reference for radius values

### D-07: Bootstrap 5 Retained as CSS Framework [LOCKED]
- Keep Bootstrap 5 as the base CSS framework (already in project)
- Override Bootstrap theme variables for dark mode
- Layer glassmorphism and custom styles on top of Bootstrap
- Bootstrap Icons retained for icon library (already in project)

## Deferred Ideas
- None specified

## Agent's Discretion
- Specific color hex values (must meet contrast requirements)
- Exact glassmorphism CSS values (blur, transparency, border)
- Border radius pixel values (follow M3 shape scale)
- Specific font choices (system fonts or web fonts)
- Transition/animation timing
