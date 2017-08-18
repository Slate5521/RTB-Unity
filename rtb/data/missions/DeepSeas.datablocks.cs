datablock ParticleData(seaBubbleParticle)
{
	textureName		  = "~/data/particles/bubble";
	dragCoefficient	 = 0.0;
	windCoefficient		= 0.0;
	gravityCoefficient = -0.005;
	inheritedVelFactor = 0.00;
	useInvAlpha		  = false;
	spinRandomMin		= -30.0;
	spinRandomMax		= 30.0;

	lifetimeMS			= 5000000;
	lifetimeVarianceMS = 0;

	times[0] = 0.0;
	times[1] = 0.9;
	times[2] = 1.0;

	colors[0] = "1.0 1.0 1 1";
	colors[1] = "1.0 1.0 1 1";
	colors[2] = "1.0 1.0 1.0 0";

	sizes[0] = 0.3;
	sizes[1] = 0.9;
	sizes[2] = 1.0;
};

datablock ParticleEmitterData(seaBubbleParticleEmitter)
{
	particles = "seaBubbleParticle";

	ejectionPeriodMS = 150;
	periodVarianceMS = 0;

	ejectionVelocity = 0.0125;
	velocityVariance = 0.0125;
	ejectionoffset=64;

	thetaMin = 0.0;
	thetaMax = 180.0;
	phireferencevel=0.0;
	phivariance=359;
};