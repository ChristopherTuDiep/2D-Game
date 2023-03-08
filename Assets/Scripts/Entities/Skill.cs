public class Skill
{
    public string skillName;
    public int skillCost;
    public int skillDamage;
    public bool isPhysical;

    public Skill()
    {
        skillName = "Basic Skill";
        skillCost = 5;
        skillDamage = 40;
        isPhysical = false;
    }

    public Skill(string skillName, int skillCost, int skillDamage, bool isPhysical)
    {
        this.skillName = skillName;
        this.skillCost = skillCost;
        this.skillDamage = skillDamage;
        this.isPhysical = isPhysical;
    }

    public void ActivateSkill()
    {
        BattleHandler.SkillAttack(skillDamage, isPhysical);
    }
}
