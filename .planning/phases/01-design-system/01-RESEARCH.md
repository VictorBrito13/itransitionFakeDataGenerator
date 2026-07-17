# Phase 1 Research: Design System Foundation

## Standard Stack

### CSS Framework: Bootstrap 5 (Retained)
- Already in project via CDN
- Supports CSS custom properties for theming
- Dark mode support via `[data-bs-theme="dark"]` attribute
- Bootstrap 5.3+ has built-in dark color scheme support

### Icon Library: Bootstrap Icons (Retained)
- Already in project via CDN
- 2000+ icons covering all needed actions
- Consistent stroke/fill style
- Works well with glassmorphism (SVG-based)

### Glassmorphism CSS Technique
- `backdrop-filter: blur(16px)` for frosted glass effect
- Semi-transparent backgrounds: `rgba(255, 255, 255, 0.05-0.15)`
- Subtle border: `1px solid rgba(255, 255, 255, 0.1-0.2)`
- Box shadow for depth: `0 8px 32px rgba(0, 0, 0, 0.3)`
- Requires background with some visual texture/gradient for glass to be visible

### Material Design 3 Shape Scale
M3 defines shape tokens for border radius consistency:
- **None:** 0px
- **Extra Small (xs):** 4px
- **Small (sm):** 8px
- **Medium (md):** 12px
- **Large (lg):** 16px
- **Extra Large (xl):** 28px
- **Full:** 9999px (pill/circle)

Component mapping:
- Buttons: md (12px) or lg (16px)
- Cards: lg (16px) or xl (28px)
- Inputs: sm (8px) or md (12px)
- Dialogs: xl (28px)
- Navigation: full (9999px) for pills

## Architecture Patterns

### CSS Custom Properties (Design Tokens)
Define all design values as CSS variables on `:root`:
```
--color-primary: #xxx;
--color-surface: #xxx;
--glass-blur: 16px;
--glass-bg: rgba(255,255,255,0.1);
--glass-border: rgba(255,255,255,0.18);
--radius-sm: 8px;
--radius-md: 12px;
--radius-lg: 16px;
```

### Bootstrap Theme Override Strategy
1. Set `[data-bs-theme="dark"]` on `<html>` or `<body>`
2. Override Bootstrap CSS variables for dark palette
3. Add custom glass utility classes
4. Layer custom styles in site.css after Bootstrap

### Information Architecture Principles Applied
1. **Organization:** Group related controls (data settings vs actions)
2. **Labeling:** Clear labels with icons reinforcing meaning
3. **Findability:** Primary controls visible, secondary in logical groups
4. **Accessibility:** ARIA labels, keyboard navigation, contrast ratios

## Common Pitfalls

### Glassmorphism Pitfalls
- **Performance:** `backdrop-filter` is GPU-intensive; limit to key containers
- **Contrast:** Text on glass must meet WCAG AA (4.5:1 for normal text)
- **Fallback:** Provide solid background fallback for browsers without `backdrop-filter`
- **Background required:** Glass effect invisible on flat solid backgrounds — need gradient or image

### Dark Theme Pitfalls
- **Pure black (#000):** Avoid — causes eye strain and smearing on OLED. Use #0a0a0a to #1a1a1a range
- **Low contrast:** Don't use light gray text on dark gray. Minimum 4.5:1 ratio
- **Elevation:** Dark theme uses lighter surfaces for higher elevation (inverse of light theme)
- **Color saturation:** Highly saturated colors vibrate on dark backgrounds. Use desaturated pastels

### Bootstrap Dark Mode Pitfalls
- Bootstrap's dark mode changes component colors but doesn't add glassmorphism
- Need custom CSS layered on top — Bootstrap alone is insufficient
- Some Bootstrap components need manual override (tables, cards, forms)

## Color Palette Direction

### Custom Dark Theme Palette (Proposal)
Since user wants "own colors" not Material default:

**Option A: Teal/Cyan Accent**
- Primary: #00D4AA (teal-green) — fresh, modern, tech-forward
- Secondary: #7C4DFF (soft purple) — complementary accent
- Surface: #0D1117 (deep dark blue-gray) — GitHub-dark inspired
- Surface Glass: rgba(13, 17, 23, 0.7) — for glass containers
- Text Primary: #E6EDF3 — high contrast on dark
- Text Secondary: #8B949E — muted secondary text
- Error: #FF6B6B — soft red
- Success: #3FB950 — soft green

**Option B: Amber/Gold Accent**
- Primary: #FFB547 (warm amber) — inviting, distinctive
- Secondary: #4FC3F7 (sky blue) — cool complement
- Surface: #121212 (pure dark) — Material dark surface
- Similar glass/text colors

**Recommendation:** Option A (Teal/Cyan) — more modern, better contrast on dark, tech-appropriate for a data generator tool.

## Package Legitimacy Audit
No new packages required — using existing Bootstrap 5 and Bootstrap Icons (already in project via CDN).
